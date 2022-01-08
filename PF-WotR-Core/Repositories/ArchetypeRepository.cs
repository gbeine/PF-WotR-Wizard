using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Facades;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Repositories
{
    public static class ArchetypeRepository
    {
        private static readonly Dictionary<String, BlueprintArchetype> ArchetypesCache = new Dictionary<String, BlueprintArchetype>();

        public static BlueprintArchetype Create(string name, string guid)
        {
            return Library.Create<BlueprintArchetype>(name, guid);
        }

        public static BlueprintArchetype Get(string guid)
        {
            return Library.Get<BlueprintArchetype>(guid);
        }

        public static List<BlueprintArchetype> GetAll()
        {
            if (ArchetypesCache.Count == 0)
            {
                List<BlueprintCharacterClass> characterClasses = CharacterClassesRepository.GetAll();
                foreach (var characterClass in characterClasses)
                {
                    Mod.Debug(characterClass.Name);
                    foreach (var archetype in characterClass.Archetypes)
                    {
                        ArchetypesCache[archetype.AssetGuid.ToString()] = archetype;
                        Mod.Debug("--------------------------------------------------");
                        Mod.Debug(archetype.AssetGuid.ToString());
                        Mod.Debug(archetype.Name);
                    }
                }
            }

            return ArchetypesCache.Values.ToList();
        }
    }
}
