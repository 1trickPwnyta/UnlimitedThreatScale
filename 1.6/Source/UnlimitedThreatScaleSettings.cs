using UnityEngine;
using Verse;

namespace UnlimitedThreatScale
{
    public class UnlimitedThreatScaleSettings : ModSettings
    {
        public static bool UncapThreatPoints = false;
        public static int ThreatPointsCap = 10000;  // Default same as vanilla
        public static bool UncapWealthCurves = false;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);

            if (Find.Storyteller?.difficulty?.threatScale != null)
            {
                DoThreatScaleWidget(ref listingStandard, ref Find.Storyteller.difficulty.threatScale);
            }

            listingStandard.CheckboxLabeled("UnlimitedThreatScale_UncapThreatPoints".Translate(), ref UncapThreatPoints);

            if (!UncapThreatPoints)
            {
                listingStandard.Label("UnlimitedThreatScale_ThreatPointsCap".Translate());
                string buffer = ThreatPointsCap.ToString();
                listingStandard.IntEntry(ref ThreatPointsCap, ref buffer, 100);
                ThreatPointsCap = Mathf.Max(35, ThreatPointsCap);
            }

            listingStandard.CheckboxLabeled("UnlimitedThreatScale_UncapWealthCurves".Translate(), ref UncapWealthCurves, "UnlimitedThreatScale_UncapWealthCurvesDesc".Translate());

            listingStandard.End();
        }

        public static void DoThreatScaleWidget(ref Listing_Standard listing, ref float value)
        {
            int num = (int) GenMath.RoundTo(value * 100, 1f);
            TaggedString label = "Difficulty_ThreatScale_Label".Translate() + ": " + value.ToStringByStyle(ToStringStyle.PercentZero, ToStringNumberSense.Absolute);
            listing.Label(label, -1f, "Difficulty_ThreatScale_Info".Translate());
            string buffer = num.ToString();
            int num2 = num;
            listing.IntEntry(ref num, ref buffer, 10);
            if (num2 != num)
            {
                value = GenMath.RoundTo(num / 100f, 0.01f);
            }
        }

        public override void ExposeData()
        {
            Scribe_Values.Look(ref UncapThreatPoints, "UncapThreatPoints");
            Scribe_Values.Look(ref ThreatPointsCap, "ThreatPointsCap");
            Scribe_Values.Look(ref UncapWealthCurves, "UncapWealthCurves");
        }
    }
}
