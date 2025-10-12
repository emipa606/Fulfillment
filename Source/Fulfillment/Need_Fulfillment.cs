using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace FulfillmentModNamespace;

public class Need_Fulfillment : Need
{
    private int lastGainTick = -999;

    private int ticksAtZero;

    public Need_Fulfillment(Pawn pawn)
        : base(pawn)
    {
        try
        {
            def = DefDatabase<NeedDef>.GetNamed("Fulfillment_Fulfillment");
        }
        catch (Exception ex)
        {
            Log.Error("Need_Fulfillment constructor: " + ex.Message);
        }

        threshPercents = [0.05f, 0.2f, 0.4f, 0.55f, 0.8f, 0.95f];
    }

    private float FulfillmentRate
    {
        get
        {
            if (pawn != null)
            {
                var statValue = pawn.GetStatValue(StatDefOf.Comfort);
                return statValue > 0f ? statValue : 1f;
            }

            Log.Error("FulfillmentRate: Pawn is null");
            return 1f;
        }
    }

    private FulfillmentCategory CurCategory
    {
        get
        {
            return CurLevel switch
            {
                < 0.05f => FulfillmentCategory.VeryLow, < 0.2f and >= 0.05f => FulfillmentCategory.Low,
                < 0.4f and >= 0.2f => FulfillmentCategory.MediumLow, >= 0.5f and < 0.65f => FulfillmentCategory.Medium,
                >= 0.65f and < 0.8f => FulfillmentCategory.MediumHigh, _ => FulfillmentCategory.High
            };
        }
    }

    private float FallPerTick
    {
        get
        {
            var num = 1.2E-06f * FulfillmentRate;
            return CurLevel switch
            {
                >= 0.95f => num * 1.2f, >= 0.8f => num * 1.1f, _ => num
            };
        }
    }

    private bool ReceivingFulfillment => Find.TickManager.TicksGame < lastGainTick + 10;

    public override int GUIChangeArrow
    {
        get
        {
            if (ReceivingFulfillment)
            {
                return 1;
            }

            return -1;
        }
    }

    public void GainFulfillment(SkillRecord skill)
    {
        var num = 1E-05f;
        if (CurLevel <= 0.05f)
        {
            num *= 1.2f;
        }

        switch (skill.passion)
        {
            case Passion.Minor:
                num *= 1f;
                break;
            case Passion.Major:
                num *= 1.25f;
                break;
        }

        lastGainTick = Find.TickManager.TicksGame;
        CurLevel = Mathf.Min(CurLevel + num, 1f);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref ticksAtZero, "ticksAtZero");
    }

    public override void SetInitialLevel()
    {
        CurLevel = 0.3f;
    }

    public override void NeedInterval()
    {
        CurLevel -= FallPerTick * 150f;
        if (CurLevel < 0f)
        {
            CurLevel = 0f;
        }

        ApplyMoodEffects();
        switch (CurCategory)
        {
            case <= FulfillmentCategory.Low when pawn?.CurrentBed() != null && pawn.health.capacities.CanBeAwake:
                CurLevel = 1f;
                break;
            case <= FulfillmentCategory.Low:
                ticksAtZero += 150;
                break;
            default:
                ticksAtZero = 0;
                break;
        }
    }

    private void ApplyMoodEffects()
    {
        if (pawn.needs.mood == null)
        {
            return;
        }

        var thoughtDef = CurLevel switch
        {
            < 0.05f => CustomThoughtDefOf.Fulfillment_FulfillmentVeryLow,
            < 0.2f and >= 0.05f => CustomThoughtDefOf.Fulfillment_FulfillmentLow,
            < 0.4f and >= 0.2f => CustomThoughtDefOf.Fulfillment_FulfillmentMediumLow,
            >= 0.5f and < 0.65f => CustomThoughtDefOf.Fulfillment_FulfillmentMedium,
            >= 0.65f and < 0.8f => CustomThoughtDefOf.Fulfillment_FulfillmentMediumHigh,
            >= 0.8f and < 0.95f => CustomThoughtDefOf.Fulfillment_FulfillmentHigh,
            >= 0.95f => CustomThoughtDefOf.Fulfillment_FulfillmentVeryHigh, _ => null
        };

        if (thoughtDef != null)
        {
            ApplyHediffOrThought(thoughtDef);
        }
    }

    private void ApplyHediffOrThought(ThoughtDef thoughtDef)
    {
        if (pawn.needs.mood.thoughts.memories.Memories.Exists(m => m.def == thoughtDef))
        {
            pawn.needs.mood.thoughts.memories.Memories.Find(m => m.def == thoughtDef)?.Renew();
        }
        else
        {
            pawn.needs.mood.thoughts.memories.TryGainMemory(thoughtDef);
        }
    }
}