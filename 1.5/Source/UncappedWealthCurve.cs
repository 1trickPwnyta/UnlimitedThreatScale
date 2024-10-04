using HarmonyLib;
using RimWorld;
using System.Linq;
using Verse;

namespace UnlimitedThreatScale
{
    public class UncappedWealthCurve : SimpleCurve
    {
        public static UncappedWealthCurve PointsPerWealthCurve = new UncappedWealthCurve((SimpleCurve)typeof(StorytellerUtility).Field("PointsPerWealthCurve").GetValue(null));
        public static UncappedWealthCurve PointsPerColonistByWealthCurve = new UncappedWealthCurve((SimpleCurve)typeof(StorytellerUtility).Field("PointsPerColonistByWealthCurve").GetValue(null));
        public static UncappedWealthCurve PointsFactorForColonyMechsCurve = new UncappedWealthCurve((SimpleCurve)typeof(StorytellerUtility).Field("PointsFactorForColonyMechsCurve").GetValue(null));
        public static UncappedWealthCurve PointsFactorForColonyMutantsCurve = new UncappedWealthCurve((SimpleCurve)typeof(StorytellerUtility).Field("PointsFactorForColonyMutantsCurve").GetValue(null));

        public UncappedWealthCurve(SimpleCurve curve)
        {
            SetPoints(curve.Points);
        }

        public float GetUncappedWealthCurveValue(float input)
        {
            CurvePoint lastPoint = Points.Last();
            CurvePoint secondLastPoint = Points[Points.Count - 2];

            float inputDiff = lastPoint.x - secondLastPoint.x;
            float outputDiff = lastPoint.y - secondLastPoint.y;
            float uncappedRate = outputDiff / inputDiff;
            float excessInput = input - lastPoint.x;
            float excessOutput = excessInput * uncappedRate;
            return excessOutput + lastPoint.y;
        }
    }
}
