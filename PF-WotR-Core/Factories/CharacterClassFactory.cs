using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Factories
{
    public class CharacterClassFactory
    {
        public BlueprintCharacterClass CreateClass(string name, string guid)
        {
            Mod.Debug($"Create class {name} with id {guid}");

            BlueprintCharacterClass characterClass = CharacterClassesRepository.Create(name, guid);
            
            Mod.Debug($"DONE: Create class {name} with id {guid}");
            return characterClass;
        }

        public BlueprintCharacterClass CreateClassFrom(string name, string guid, string fromAssetGuid)
        {
            Mod.Debug($"Create class {name} with id {guid} from {fromAssetGuid}");

            BlueprintCharacterClass original = CharacterClassesRepository.Get(fromAssetGuid);
            BlueprintCharacterClass clone = CharacterClassesRepository.Create(name, guid);
           
            clone.Clone(original);

            Mod.Debug($"DONE: Create class {name} with id {guid}");
            return clone;
        }
    }
}
