using HarmonyLib;
using Verse;
using System;

namespace EmptyPlayLog
{
    [HarmonyPatch(typeof(Dialog_DebugActionsMenu), "DoListingItems_MapManagement")]
    internal static class Dialog_DebugActionsMenu_Patch_DoListingItems_MapManagement
    {
        [HarmonyPostfix]
        public static void Postfix(Dialog_DebugActionsMenu __instance)
        {
            try
            {
                DoListingItems_Mod(__instance);
            }
            catch(Exception e)
            {
                Log.Message($"EmptyPlayLog : DoListingItems_Postfix error - {e.Message}", true);
            }
        }

        private static void DoListingItems_Mod(Dialog_DebugActionsMenu __instance)
        {
            Action clear = new Action(DebugAction_ClearCraftThoughts);
               
            Traverse.Create(__instance).Method("DoGap").GetValue();
            Traverse.Create(__instance).Method("DoLabel", "Mods - Misc").GetValue();
            Traverse.Create(__instance).Method("DebugAction", "Clear Play Log", clear).GetValue();
        }

        private static void DebugAction_ClearCraftThoughts()
        {
            Find.PlayLog.AllEntries.Clear();
        }
    }
}
