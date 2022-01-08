using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Root;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Facades;
using PF_WotR_Core.JsonTypes;

namespace PF_WotR_Core.Repositories
{
    public static class CharacterClassesRepository
    {
        private static readonly Dictionary<String, BlueprintCharacterClass> CharacterClassesCache = 
            new Dictionary<String, BlueprintCharacterClass>();

        private static readonly Dictionary<String, CharacterClass> JsonCharacterClassesCache = 
            new Dictionary<String, CharacterClass>();

        public static BlueprintCharacterClass Create(string name, string guid)
        {
            return Library.Create<BlueprintCharacterClass>(name, guid);
        }

        public static BlueprintCharacterClass Get(string guid)
        {
            return Library.Get<BlueprintCharacterClass>(guid);
        }
        
        public static List<BlueprintCharacterClass> GetAll()
        {
            if (CharacterClassesCache.Count == 0)
            {
                ProgressionRoot root = Library.GetProgression();

                foreach (var blueprintCharacterClassReference in root.GetCharacterClassReferences())
                {
                    BlueprintCharacterClass blueprintCharacterClass = blueprintCharacterClassReference.Get();

                    CharacterClassesCache[blueprintCharacterClassReference.Guid.ToString()] = blueprintCharacterClass;
                    JsonCharacterClassesCache[blueprintCharacterClass.AssetGuid.ToString()] = new CharacterClass(blueprintCharacterClass);
                }
            }

            return CharacterClassesCache.Values.ToList();
        }

        public static List<CharacterClass> GetAllSerializable()
        {
            GetAll();
            return JsonCharacterClassesCache.Values.ToList();
        }

        public static void Add(BlueprintCharacterClass blueprintCharacterClass)
        {
            ProgressionRoot progression = Library.GetProgression();
            List<BlueprintCharacterClassReference> references = progression.GetCharacterClassReferences();
            references.Add(blueprintCharacterClass.ToReference<BlueprintCharacterClassReference>());
            references.Sort(
                (Comparison<BlueprintCharacterClassReference>)((x, y) =>
                {
                    BlueprintCharacterClass blueprint1 = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>(x.Guid);
                    BlueprintCharacterClass blueprint2 = ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>(y.Guid);
                    return blueprint1 == null || blueprint2 == null
                        ? 1
                        : (blueprint1.PrestigeClass == blueprint2.PrestigeClass
                            ? blueprint1.NameSafe().CompareTo(blueprint2.NameSafe())
                            : (blueprint1.PrestigeClass
                                ? 1
                                : -1));
                }));
            progression.SetCharacterClassReferences(references);

            if (!blueprintCharacterClass.IsArcaneCaster && !blueprintCharacterClass.IsDivineCaster)
                return;

            // What are we doing here???
            BlueprintProgression blueprintProgression = ResourcesLibrary.TryGetBlueprint<BlueprintProgression>("fe9220cdc16e5f444a84d85d5fa8e3d5");
            blueprintProgression.SetClass(blueprintCharacterClass);
        }
    }
}

