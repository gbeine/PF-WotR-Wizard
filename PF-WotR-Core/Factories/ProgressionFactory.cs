using System;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Factories
{
    public class ProgressionFactory
    {
        public BlueprintProgression CreateProgressionFrom(String name, String guid, String fromAssetGuid)
        {
            Mod.Debug($"Create progression {name} with id {guid} based on {fromAssetGuid}");

            BlueprintProgression original = ProgressionRepository.Get(fromAssetGuid);
            BlueprintProgression clone = ProgressionRepository.Create(name, guid);
           
            clone.Clone(original);

            Mod.Debug($"DONE: Create progression {name} with id {guid} based on {fromAssetGuid}");
            return clone;

        }

        public BlueprintProgression CreateProgression(String name, String guid)
        {
            Mod.Debug($"Create progession {name} with id {guid}");

            BlueprintProgression progression = ProgressionRepository.Create(name, guid);

            Mod.Debug($"DONE: Create progession {name} with id {guid}");
            return progression;
        }
    }
}
