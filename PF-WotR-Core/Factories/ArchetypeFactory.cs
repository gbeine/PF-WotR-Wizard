using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Factories
{
    public class ArchetypeFactory
    {
        public BlueprintArchetype CreateArchetype(string name, string guid)
        {
            Mod.Debug($"Create archetype {name} with id {guid}");

            BlueprintArchetype archetype = ArchetypeRepository.Create(name, guid);
            
            Mod.Debug($"DONE: Create archetype {name} with id {guid}");
            return archetype;
        }
        
        public BlueprintArchetype CreateArchetypeFrom(string name, string guid, string fromAssetGuid)
        {
            Mod.Debug($"Create archetype {name} with id {guid} from {fromAssetGuid}");
            
            BlueprintArchetype original = ArchetypeRepository.Get(fromAssetGuid);
            BlueprintArchetype clone = ArchetypeRepository.Create(name, guid);
            
            Mod.Debug($"DONE: Create archetype {name} with id {guid}");
            return clone;
        }

    }
}
