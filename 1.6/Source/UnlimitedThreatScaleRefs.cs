using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;

namespace UnlimitedThreatScale
{
    public static class UnlimitedThreatScaleRefs
    {
        public static FieldInfo f_UnlimitedThreatScaleSettings_UncapThreatPoints = AccessTools.Field(typeof(UnlimitedThreatScaleSettings), nameof(UnlimitedThreatScaleSettings.UncapThreatPoints));
        public static FieldInfo f_UnlimitedThreatScaleSettings_ThreatPointsCap = AccessTools.Field(typeof(UnlimitedThreatScaleSettings), nameof(UnlimitedThreatScaleSettings.ThreatPointsCap));
        public static FieldInfo f_PawnGroupMakerParms_points = AccessTools.Field(typeof(PawnGroupMakerParms), nameof(PawnGroupMakerParms.points));
        public static FieldInfo f_UncappedWealthCurve_PointsPerWealthCurve = AccessTools.Field(typeof(UncappedWealthCurve), nameof(UncappedWealthCurve.PointsPerWealthCurve));
        public static FieldInfo f_UncappedWealthCurve_PointsPerColonistByWealthCurve = AccessTools.Field(typeof(UncappedWealthCurve), nameof(UncappedWealthCurve.PointsPerColonistByWealthCurve));
        public static FieldInfo f_UncappedWealthCurve_PointsFactorForColonyMechsCurve = AccessTools.Field(typeof(UncappedWealthCurve), nameof(UncappedWealthCurve.PointsFactorForColonyMechsCurve));
        public static FieldInfo f_UncappedWealthCurve_PointsFactorForColonyMutantsCurve = AccessTools.Field(typeof(UncappedWealthCurve), nameof(UncappedWealthCurve.PointsFactorForColonyMutantsCurve));
        public static FieldInfo f_StorytellerUtility_PointsPerWealthCurve = AccessTools.Field(typeof(StorytellerUtility), "PointsPerWealthCurve");
        public static FieldInfo f_StorytellerUtility_PointsPerColonistByWealthCurve = AccessTools.Field(typeof(StorytellerUtility), "PointsPerColonistByWealthCurve");
        public static FieldInfo f_StorytellerUtility_PointsFactorForColonyMechsCurve = AccessTools.Field(typeof(StorytellerUtility), "PointsFactorForColonyMechsCurve");
        public static FieldInfo f_StorytellerUtility_PointsFactorForColonyMutantsCurve = AccessTools.Field(typeof(StorytellerUtility), "PointsFactorForColonyMutantsCurve");
    }
}
