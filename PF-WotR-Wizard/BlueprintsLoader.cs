using System;
using System.Collections.Generic;
using System.IO;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Wizard
{
    [HarmonyPatch(typeof(BlueprintsCache), "Init")]
    public class BlueprintsLoader
    {
        private static bool loaded = false;
        private static readonly string blueprintDirectory = Mod.modEntryPath + "/Blueprints";

        [HarmonyPriority(Priority.First)]
        public static void Postfix()
        {
            // if (loaded)
            // {
            //     Mod.Log("Already loaded...");
            // }
            // else
            // {
            try
            {
                DumpClasses(CharacterClassesRepository.GetAllSerializable());
                loaded = true;
            }
            catch (Exception e)
            {
                Mod.Error(e);
                throw;
            }
            // }
        }

        private static void DumpClasses(List<CharacterClass> characterClasses)
        {
            foreach (var characterClass in characterClasses)
            {
                File.WriteAllText(
                    blueprintDirectory + "/" + characterClass.Name + ".json",
                    characterClass.ToJson());
            }
        }
    }
}