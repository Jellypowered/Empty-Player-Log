using HarmonyLib;
using System.Reflection;
using Verse;

namespace EmptyPlayLog
{
    [StaticConstructorOnStartup]
    internal class PatchLoader
    {
        static PatchLoader()
        {
            var harmony = new Harmony("empty.play.log");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            Log.Message("empty.play.log : patched DoListingItems", false);
        }
    }
}
