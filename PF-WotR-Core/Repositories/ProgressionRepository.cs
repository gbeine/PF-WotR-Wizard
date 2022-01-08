using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Facades;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Repositories
{
    public static class ProgressionRepository
    {
        private static readonly Dictionary<String, BlueprintProgression> ProgressionsCache = new Dictionary<String, BlueprintProgression>();

        public static BlueprintProgression Create(string name, string guid)
        {
            return Library.Create<BlueprintProgression>(name, guid);
        }

        public static BlueprintProgression Get(string guid)
        {
            return Library.Get<BlueprintProgression>(guid);
        }
        
        public static List<BlueprintProgression> GetAll()
        {
            if (ProgressionsCache.Count == 0)
            {
                List<BlueprintCharacterClass> characterClasses = CharacterClassesRepository.GetAll();
                foreach (var characterClass in characterClasses)
                {
                    Mod.Debug("--------------------------------------------------");
                    Mod.Debug(characterClass.Name);
                    BlueprintProgression progression = characterClass.Progression; 
                    ProgressionsCache[progression.AssetGuid.ToString()] = progression;
                    Mod.Debug(progression.AssetGuid.ToString());
                    foreach (var levelEntry in progression.LevelEntries)
                    {
                        Mod.Debug("--------------------");
                        Mod.Debug(levelEntry.Level.ToString());
                        foreach (var feature in levelEntry.Features)
                        {
                            Mod.Debug(feature.AssetGuid.ToString());
                            Mod.Debug(feature.name);
                        }
                    }
                }
                List<BlueprintArchetype> archetypes = ArchetypeRepository.GetAll();
                foreach (var archetype in archetypes)
                {
                    Mod.Debug("--------------------------------------------------");
                    Mod.Debug(archetype.Name);
                    foreach (var levelEntry in archetype.AddFeatures)
                    {
                        Mod.Debug("--------------------");
                        Mod.Debug(levelEntry.Level.ToString());
                        foreach (var feature in levelEntry.Features)
                        {
                            Mod.Debug(feature.AssetGuid.ToString());
                            Mod.Debug(feature.name);
                        }
                    }
                }
            }

            return ProgressionsCache.Values.ToList();
        }

    }
}