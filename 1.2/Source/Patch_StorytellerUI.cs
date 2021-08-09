using RimWorld;
using Verse;
using HarmonyLib;

namespace UnlimitedThreatScale
{
    // Patches the vanilla custom difficulty slider to be a free-entry text box instead

    [HarmonyPatch(typeof(StorytellerUI))]
    [HarmonyPatch("DrawCustomDifficultySlider")]
    public static class Patch_StorytellerUI_DrawCustomDifficultySlider
    {
        public static bool Prefix(ref Listing_Standard listing, ref string optionName, ref float value)
        {
            // If the optionName is threatScale, replace the slider with our widget
            if (optionName == "threatScale")
            {
                UnlimitedThreatScaleSettings.DoThreatScaleWidget(ref listing, ref value);
                return false;
			}

            return true;
        }
    }
}
