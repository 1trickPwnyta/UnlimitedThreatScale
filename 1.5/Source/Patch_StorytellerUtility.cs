using System.Collections.Generic;
using System.Reflection.Emit;
using RimWorld;
using HarmonyLib;
using UnityEngine;

namespace UnlimitedThreatScale
{
    // Removes the vanilla threat points cap and replaces it with the mod's threat points cap

    [HarmonyPatch(typeof(StorytellerUtility))]
    [HarmonyPatch("DefaultThreatPointsNow")]
    public static class Patch_StorytellerUtility_DefaultThreatPointsNow
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator il)
        {
            bool foundThreatPointsCap = false;
            bool foundRet = false;
            Label postThreatPointsCapApplied = il.DefineLabel();
            foreach (CodeInstruction instruction in instructions)
            {
                // Find instruction to store 10000 (hard-coded vanilla threat points cap) and add settings check to either skip the clamp or use a value other than 10000
                if (!foundThreatPointsCap && instruction.opcode == OpCodes.Ldc_R4 && (instruction.operand as float?).ToString() == "10000")
                {
                    yield return new CodeInstruction(OpCodes.Ldsfld, UnlimitedThreatScaleRefs.f_UnlimitedThreatScaleSettings_UncapThreatPoints);
                    yield return new CodeInstruction(OpCodes.Brtrue, postThreatPointsCapApplied);
                    yield return new CodeInstruction(OpCodes.Ldsfld, UnlimitedThreatScaleRefs.f_UnlimitedThreatScaleSettings_ThreatPointsCap);
                    yield return new CodeInstruction(OpCodes.Conv_R4);
                    foundThreatPointsCap = true;
                    continue;
                }

                // Find return instruction and add a max function to calculate uncapped threat points if above code directs here
                if (foundThreatPointsCap && !foundRet && instruction.opcode == OpCodes.Ret)
                {
                    yield return instruction;
                    CodeInstruction maxInstruction = new CodeInstruction(OpCodes.Call, SymbolExtensions.GetMethodInfo(() => Mathf.Max(0f, 0f)));
                    maxInstruction.labels.Add(postThreatPointsCapApplied);
                    yield return maxInstruction;
                    yield return new CodeInstruction(OpCodes.Ret);
                    foundRet = true;
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
