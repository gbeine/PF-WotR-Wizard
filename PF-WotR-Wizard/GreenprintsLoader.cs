using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using PF_WotR_Core.Loader;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Wizard
{
    [HarmonyPatch(typeof(BlueprintsCache), "Init")]
    public class GreenprintsLoader
    {
        private static bool loaded = false;

        private static readonly Dictionary<String, Action<String>> _loader = new Dictionary<string, Action<string>>();
        private static readonly string greenprintsDirectory = Mod.modEntryPath + "/Greenprints";
        private static readonly Regex regex = new Regex(".*(Archetype|AreaEffect|Buff|Cantrips|Class|Feature|Orisons|Proficiencies|Progression|Selection|SpellAbility|Spellbook).json");

        [HarmonyPriority(Priority.First)]
        public static void Postfix()
        {
            Mod.Log($"Loading from {greenprintsDirectory}");
            if (Directory.Exists(greenprintsDirectory))
            {
                Mod.Log($"Loading from {greenprintsDirectory}");
                IOrderedEnumerable<string> files = Directory.GetFiles(greenprintsDirectory, "*.json").OrderBy(f => f);
                foreach (var file in files)
                {
                    Match match = regex.Match(file);
                    if (match.Success)
                    {
                        try
                        {
                            Mod.Log("------------------------------------------------------------------------------");
                            Mod.Log($"Loading from file {file}");

                            string type = match.Groups[1].Value;

                            _loader[type](file);

                            Mod.Log($"DONE: Loading from file {file}");
                            Mod.Log("------------------------------------------------------------------------------");
                        }
                        catch (Exception e)
                        {
                            Mod.Error(e.Message);
                            Mod.Error(e.StackTrace);
                        }
                    }
                }
            }
        }
        
        static GreenprintsLoader()
        {
            _loader.Add("Class", file => new CharacterClassLoader(file).load());
        }
    }
}
