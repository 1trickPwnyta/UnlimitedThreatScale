using UnityEngine;
using Verse;
using HarmonyLib;

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
