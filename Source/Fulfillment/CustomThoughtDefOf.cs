using RimWorld;

namespace FulfillmentModNamespace;

[DefOf]
public static class CustomThoughtDefOf
{
    public static ThoughtDef Fulfillment_FulfillmentVeryLow;

    public static ThoughtDef Fulfillment_FulfillmentLow;

    public static ThoughtDef Fulfillment_FulfillmentMediumLow;

    public static ThoughtDef Fulfillment_FulfillmentMedium;

    public static ThoughtDef Fulfillment_FulfillmentMediumHigh;

    public static ThoughtDef Fulfillment_FulfillmentHigh;

    public static ThoughtDef Fulfillment_FulfillmentVeryHigh;

    static CustomThoughtDefOf()
    {
        DefOfHelper.EnsureInitializedInCtor(typeof(CustomThoughtDefOf));
    }
}