using System;
using Kingmaker.Blueprints.Classes.Spells;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Factories
{
    public class SpellbookFactory
    {
        public BlueprintSpellbook CreateSpellbookFrom(String name, String guid, String fromAssetGuid)
        {
            Mod.Debug($"Create spellbook {name} with id {guid} based on {fromAssetGuid}");

            BlueprintSpellbook original = SpellbookRepository.Get(fromAssetGuid);
            BlueprintSpellbook clone = SpellbookRepository.Create(name, guid);
           
            clone.Clone(original);

            Mod.Debug($"DONE: Create spellbook {name} with id {guid} based on {fromAssetGuid}");
            return clone;

        }

        public BlueprintSpellbook CreateSpellbook(String name, String guid)
        {
            Mod.Debug($"Create spellbook {name} with id {guid}");

            BlueprintSpellbook spellbook = SpellbookRepository.Create(name, guid);

            Mod.Debug($"DONE: Create spellbook {name} with id {guid}");
            return spellbook;
        }

    }
}