using Verse;

namespace EmptyPawnLog
{ 
    public static class AddCraftThoughtClearAction
    {
        [DebugAction(DebugActionCategories.MapManagement, "Clear Pawn Log...", allowedGameStates =AllowedGameStates.PlayingOnMap)]
               
        private static void ClearCraftThoughts()
        {   
            Find.PlayLog.AllEntries.Clear();
        }
    }
}

