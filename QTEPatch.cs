using EFT.Hideout;
using HarmonyLib;

namespace AutoWorkout
{
    public static class QTEStateManager
    {
        public static bool HasPlayerClicked = false;
    }

    [HarmonyPatch(typeof(ShrinkingCircleQTE), nameof(ShrinkingCircleQTE.StartAction))]
    public class QTEResetPatch
    {
        static void Prefix()
        {
            QTEStateManager.HasPlayerClicked = false;
        }
    }

    [HarmonyPatch(typeof(ShrinkingCircleQTE), nameof(ShrinkingCircleQTE.method_1))]
    public class QTEClickTrackerPatch
    {
        static void Prefix()
        {
            QTEStateManager.HasPlayerClicked = true;
        }
    }

    [HarmonyPatch(typeof(ShrinkingCircleQTE), nameof(ShrinkingCircleQTE.method_3))]
    public class AutoGymTimeoutPatch
    {
        static void Prefix(ref bool success)
        {
            if (success == false && QTEStateManager.HasPlayerClicked == false)
            {
                success = true;
            }
        }
    }
}