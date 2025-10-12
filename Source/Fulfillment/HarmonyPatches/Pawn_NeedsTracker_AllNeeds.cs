using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace FulfillmentModNamespace;

[HarmonyPatch(typeof(Pawn_NeedsTracker), nameof(Pawn_NeedsTracker.AllNeeds), MethodType.Getter)]
public static class Pawn_NeedsTracker_AllNeeds
{
    private static void Postfix(Pawn_NeedsTracker __instance, ref List<Need> __result)
    {
        var pawn = (Pawn)typeof(Pawn_NeedsTracker).GetField("pawn", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.GetValue(__instance);
        if (pawn != null && pawn.RaceProps.Humanlike && !__result.Exists(n => n is Need_Fulfillment))
        {
            if (hasAnyPassion(pawn))
            {
                __result.Add(new Need_Fulfillment(pawn));
            }
        }
        else if (pawn == null)
        {
            Log.Error("Pawn_NeedsTracker_AllNeeds_Patch: Pawn is null");
        }
    }

    private static bool hasAnyPassion(Pawn pawn)
    {
        if (pawn.skills == null)
        {
            Log.Warning("Pawn_NeedsTracker_AllNeeds_Patch: Pawn skills are null, initializing.");
            pawn.skills = new Pawn_SkillTracker(pawn);
        }

        foreach (var skill in pawn.skills.skills)
        {
            if (skill.passion != Passion.None)
            {
                return true;
            }
        }

        return false;
    }
}