using HarmonyLib;
using RimWorld;
using Verse;

namespace FulfillmentModNamespace;

[HarmonyPatch(typeof(Pawn_NeedsTracker), "ShouldHaveNeed")]
public static class Pawn_NeedsTracker_ShouldHaveNeed
{
    public static void Postfix(NeedDef nd, ref bool __result, Pawn ___pawn)
    {
        if (___pawn != null && nd.defName == "Fulfillment_Fulfillment")
        {
            __result = ___pawn.RaceProps.Humanlike &&
                       FulfillmentNeedUtility.ShouldPawnTypeHaveNeed(___pawn) &&
                       hasAnyPassion(___pawn);
            return;
        }

        if (___pawn == null)
        {
            Log.Error("Pawn_NeedsTracker_ShouldHaveNeed_Patch: Pawn is null");
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