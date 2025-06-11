using UnityEngine;
using Verse;
using HarmonyLib;
using RimWorld;

namespace UnlimitedThreatScale
{
    public class UnlimitedThreatScaleMod : Mod
    {
        public const string PACKAGE_ID = "unlimitedthreatscale.1trickPonyta";
        public const string PACKAGE_NAME = "Unlimited Threat Scale";

        public static UnlimitedThreatScaleSettings Settings;

        public UnlimitedThreatScaleMod(ModContentPack content) : base(content)
        {
            Settings = GetSettings<UnlimitedThreatScaleSettings>();

            var harmony = new Harmony(PACKAGE_ID);
            harmony.PatchAll();
            harmony.Patch(AccessTools.Method(typeof(StorytellerUI), "DrawCustomDifficultySlider", new[] { typeof(Listing_Standard), typeof(string), typeof(float).MakeByRefType(), typeof(ToStringStyle), typeof(ToStringNumberSense), typeof(float), typeof(float), typeof(float), typeof(bool), typeof(float) }), AccessTools.Method(typeof(Patch_StorytellerUI_DrawCustomDifficultySlider), nameof(Patch_StorytellerUI_DrawCustomDifficultySlider.Prefix)));

            Log.Message($"[{PACKAGE_NAME}] Loaded.");
        }

        public override string SettingsCategory() => PACKAGE_NAME;

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            UnlimitedThreatScaleSettings.DoSettingsWindowContents(inRect);
        }
    }
}
