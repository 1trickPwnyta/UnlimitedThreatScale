using System.Collections.Generic;
using System.Reflection;
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
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool shouldPatchCall = false;
            foreach (CodeInstruction instruction in instructions)
            {
                // Find instruction to store 10000 (hard-coded vanilla threat points cap) and remove it
                if (instruction.opcode == OpCodes.Ldc_R4 && (instruction.operand as float?).ToString() == "10000")
                {
                    shouldPatchCall = true;
                    continue;
                }

                // Find subsequent call to Mathf.Clamp and replace it with Mathf.Max (threat points minimum of 35 has already been stored)
                if (instruction.opcode == OpCodes.Call && (MethodInfo) instruction.operand == SymbolExtensions.GetMethodInfo(() => Mathf.Clamp(0f, 0f, 0f)) && shouldPatchCall)
                {
                    instruction.operand = SymbolExtensions.GetMethodInfo(() => Mathf.Max(0f, 0f));
                    shouldPatchCall = false;
                }

                yield return instruction;
            }
        }

        public static void Postfix(ref float __result)
        {
            if (!UnlimitedThreatScaleSettings.UncapThreatPoints)
            {
                __result = Mathf.Min(__result, UnlimitedThreatScaleSettings.ThreatPointsCap);
            }
        }
    }
}
