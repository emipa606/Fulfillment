using HarmonyLib;
using Verse.AI;

namespace FulfillmentModNamespace;

[HarmonyPatch(typeof(JobDriver), nameof(JobDriver.DriverTick))]
public static class JobDriver_DriverTick
{
    private static void Postfix(JobDriver __instance)
    {
        var need_Fulfillment = __instance.pawn?.needs?.TryGetNeed<Need_Fulfillment>();
        if (need_Fulfillment == null || __instance.job?.workGiverDef == null)
        {
            return;
        }

        var relevantSkills = __instance.job.workGiverDef.workType.relevantSkills;
        foreach (var item in relevantSkills)
        {
            var skill = __instance.pawn.skills.GetSkill(item);
            if (skill == null || (int)skill.passion <= 0)
            {
                continue;
            }

            need_Fulfillment.GainFulfillment(skill);
            break;
        }
    }
}