using HarmonyLib;
using RimWorld;
using System.Reflection;

namespace UnlimitedThreatScale
{
    public static class UnlimitedThreatScaleRefs
    {
        public static FieldInfo f_UnlimitedThreatScaleSettings_UncapThreatPoints = AccessTools.Field(typeof(UnlimitedThreatScaleSettings), nameof(UnlimitedThreatScaleSettings.UncapThreatPoints));
        public static FieldInfo f_UnlimitedThreatScaleSettings_ThreatPointsCap = AccessTools.Field(typeof(UnlimitedThreatScaleSettings), nameof(UnlimitedThreatScaleSettings.ThreatPointsCap));
        public static FieldInfo f_PawnGroupMakerParms_points = AccessTools.Field(typeof(PawnGroupMakerParms), nameof(PawnGroupMakerParms.points));
    }
}
