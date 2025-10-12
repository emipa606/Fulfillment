using Mlie;
using UnityEngine;
using Verse;

namespace FulfillmentModNamespace;

public class FulfillmentMoodMod : Mod
{
    public static FulfillmentMoodSettings Settings;
    private static string currentVersion;

    public FulfillmentMoodMod(ModContentPack content)
        : base(content)
    {
        Settings = GetSettings<FulfillmentMoodSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    public override string SettingsCategory()
    {
        return "Fulfillment";
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.Label("Full.VeryUnfulfilled".Translate(Settings.moodAmountVeryLow));
        Settings.moodAmountVeryLow = Mathf.Round(listingStandard.Slider(Settings.moodAmountVeryLow, -100f, 100f));

        listingStandard.Label("Full.Unfulfilled".Translate(Settings.moodAmountLow));
        Settings.moodAmountLow = Mathf.Round(listingStandard.Slider(Settings.moodAmountLow, -100f, 100f));

        listingStandard.Label("Full.SomewhatUnfulfilled".Translate(Settings.moodAmountMediumLow));
        Settings.moodAmountMediumLow = Mathf.Round(listingStandard.Slider(Settings.moodAmountMediumLow, -100f, 100f));

        listingStandard.Label("Full.SomewhatFulfilled".Translate(Settings.moodAmountMedium));
        Settings.moodAmountMedium = Mathf.Round(listingStandard.Slider(Settings.moodAmountMedium, -100f, 100f));

        listingStandard.Label("Full.Fulfilled".Translate(Settings.moodAmountMediumHigh));
        Settings.moodAmountMediumHigh =
            Mathf.Round(listingStandard.Slider(Settings.moodAmountMediumHigh, -100f, 100f));

        listingStandard.Label("Full.HighlyFulfilled".Translate(Settings.moodAmountHigh));
        Settings.moodAmountHigh = Mathf.Round(listingStandard.Slider(Settings.moodAmountHigh, -100f, 100f));

        listingStandard.Label("Full.ExtremelyFulfilled".Translate(Settings.moodAmountVeryHigh));
        Settings.moodAmountVeryHigh = Mathf.Round(listingStandard.Slider(Settings.moodAmountVeryHigh, -100f, 100f));

        if (listingStandard.ButtonText("Full.ResetAll".Translate()))
        {
            Settings.ResetToDefaults();
        }

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("Full.ModVersion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
        base.DoSettingsWindowContents(inRect);
    }
}