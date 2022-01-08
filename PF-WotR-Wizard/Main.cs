using System.Reflection;
using HarmonyLib;
using UnityModManagerNet;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Wizard
{
    public class Main
    {
        private static Harmony HarmonyInstance;
        private static bool enabled;
        
        static bool Load(UnityModManager.ModEntry modEntry)
        {
            Mod.OnLoad(modEntry);
            Mod.logLevel = LogLevel.Debug;
            modEntry.OnToggle = OnToggle;

            HarmonyInstance = new Harmony(modEntry.Info.Id);
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
            PostPatchInitializer.Initialize();

            Mod.Debug("Loaded successfully!");
            
            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Mod.Debug("Toggled");
            enabled = value;
            return true;
        }
    }
}
