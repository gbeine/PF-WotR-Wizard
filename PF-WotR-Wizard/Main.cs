using System.Reflection;
using System.Runtime.CompilerServices;
using HarmonyLib;
using UnityModManagerNet;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Wizard
{
    public class Main
    {
        private static Harmony HarmonyInstance;
        private static bool enabled = false;
        private static bool loaded = false;
        private static bool IsModGUIShown = false;

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

        public static void Loaded()
        {
            loaded = true;
        }
        
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            Mod.Debug("Toggled");
            enabled = value;
            if (loaded && enabled)
            {
                Mod.Log("Reloading Greenprints");
                GreenprintsLoader.Load();
            }
            return true;
        }
    }
}
        
