using RimWorld;

namespace FulfillmentModNamespace;

public class Thought_CustomMood : Thought_Memory
{
    public override float MoodOffset()
    {
        return def.defName switch
        {
            "Fulfillment_FulfillmentVeryLow" => FulfillmentMoodMod.Settings.moodAmountVeryLow,
            "Fulfillment_FulfillmentLow" => FulfillmentMoodMod.Settings.moodAmountLow,
            "Fulfillment_FulfillmentMediumLow" => FulfillmentMoodMod.Settings.moodAmountMediumLow,
            "Fulfillment_FulfillmentMedium" => FulfillmentMoodMod.Settings.moodAmountMedium,
            "Fulfillment_FulfillmentMediumHigh" => FulfillmentMoodMod.Settings.moodAmountMediumHigh,
            "Fulfillment_FulfillmentHigh" => FulfillmentMoodMod.Settings.moodAmountHigh,
            "Fulfillment_FulfillmentVeryHigh" => FulfillmentMoodMod.Settings.moodAmountVeryHigh,
            _ => base.MoodOffset()
        };
    }
}