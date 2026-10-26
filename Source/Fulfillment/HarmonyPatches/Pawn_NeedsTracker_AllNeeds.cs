using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace FulfillmentModNamespace;

[HarmonyPatch(typeof(Pawn_NeedsTracker), nameof(Pawn_NeedsTracker.AllNeeds), MethodType.Getter)]
public static class Pawn_NeedsTracker_AllNeeds
{
    public static void Postfix(ref List<Need> __result, Pawn ___pawn)
    {
        if (___pawn == null || !___pawn.RaceProps.Humanlike || __result.Exists(n => n is Need_Fulfillment))
        {
            if (___pawn == null)
            {
                Log.Error("Pawn_NeedsTracker_AllNeeds_Patch: Pawn is null");
            }

            return;
        }

        if (FulfillmentNeedUtility.ShouldPawnTypeHaveNeed(___pawn) && hasAnyPassion(___pawn))
        {
            __result.Add(new Need_Fulfillment(___pawn));
        }
    }

    private static bool hasAnyPassion(Pawn pawn)
    {
        if (pawn.skills?.skills == null)
        {
            return false;
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