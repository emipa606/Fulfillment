using RimWorld;
using Verse;

namespace FulfillmentModNamespace;

public static class FulfillmentNeedUtility
{
    public static bool ShouldPawnTypeHaveNeed(Pawn pawn)
    {
        var settings = FulfillmentMoodMod.Settings;
        if (settings == null || pawn == null)
        {
            return true;
        }

        if (pawn.Faction == null)
        {
            return settings.needOnNeutralPawns;
        }

        if (pawn.Faction.IsPlayer)
        {
            return settings.needOnPlayerPawns;
        }

        var playerFaction = Faction.OfPlayerSilentFail;
        if (playerFaction == null)
        {
            return settings.needOnNeutralPawns;
        }

        var relation = pawn.Faction.RelationWith(playerFaction, true);
        if (relation == null)
        {
            return settings.needOnNeutralPawns;
        }

        if (relation.kind == FactionRelationKind.Hostile)
        {
            return settings.needOnEnemyPawns;
        }

        return settings.needOnNeutralPawns;
    }
}
