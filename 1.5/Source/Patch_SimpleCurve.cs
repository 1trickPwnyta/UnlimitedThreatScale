using HarmonyLib;
using System.Linq;
using Verse;

namespace UnlimitedThreatScale
{
    [HarmonyPatch(typeof(SimpleCurve))]
    [HarmonyPatch(nameof(SimpleCurve.Evaluate))]
    public static class Patch_SimpleCurve_Evaluate
    {
        public static bool Prefix(SimpleCurve __instance, float x, ref float __result)
        {
            if (UnlimitedThreatScaleSettings.UncapWealthCurves && __instance is UncappedWealthCurve && x > __instance.Points.Last().x)
            {
                __result = ((UncappedWealthCurve)__instance).GetUncappedWealthCurveValue(x);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
