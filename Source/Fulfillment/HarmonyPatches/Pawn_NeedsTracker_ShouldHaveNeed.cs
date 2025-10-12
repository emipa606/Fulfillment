using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace FulfillmentModNamespace;

[HarmonyPatch(typeof(Pawn_NeedsTracker), "ShouldHaveNeed")]
public static class Pawn_NeedsTracker_ShouldHaveNeed
{
    private static void Postfix(Pawn_NeedsTracker __instance, NeedDef nd, ref bool __result)
    {
        var pawn = (Pawn)typeof(Pawn_NeedsTracker).GetField("pawn", BindingFlags.Instance | BindingFlags.NonPublic)
            ?.GetValue(__instance);
        if (pawn != null && nd.defName == "Fulfillment_Fulfillment")
        {
            __result = pawn.RaceProps.Humanlike && hasAnyPassion(pawn);
        }
        else if (pawn == null)
        {
            Log.Error("Pawn_NeedsTracker_ShouldHaveNeed_Patch: Pawn is null");
        }
    }

    private static bool hasAnyPassion(Pawn pawn)
    {
        if (pawn.skills == null)
        {
            Log.Warning("Pawn_NeedsTracker_ShouldHaveNeed_Patch: Pawn skills are null, initializing.");
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