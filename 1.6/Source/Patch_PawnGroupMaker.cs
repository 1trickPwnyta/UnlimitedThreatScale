using RimWorld;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;

namespace UnlimitedThreatScale
{
    // Ignores the maximum 9,999,999 points in PawnGroupMaker

    [HarmonyPatch(typeof(PawnGroupMaker))]
    [HarmonyPatch(nameof(PawnGroupMaker.CanGenerateFrom))]
    public static class Patch_PawnGroupMaker_CanGenerateFrom
    {
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            bool finished = false;

            foreach (CodeInstruction instruction in instructions)
            {
                if (!finished && instruction.opcode == OpCodes.Ldfld && (FieldInfo)instruction.operand == UnlimitedThreatScaleRefs.f_PawnGroupMakerParms_points)
                {
                    yield return new CodeInstruction(OpCodes.Pop);
                    yield return new CodeInstruction(OpCodes.Ldc_R4, 0f);
                    finished = true;
                    continue;
                }

                yield return instruction;
            }
        }
    }
}
