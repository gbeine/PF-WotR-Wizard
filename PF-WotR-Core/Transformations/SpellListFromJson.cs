using System;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using PF_WotR_Core.Factories;
using PF_WotR_Core.Identifier;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class SpellListFromJson : JsonTransformation
    {
        private static readonly SpellbookFactory _spellbookFactory = new SpellbookFactory();

        public static BlueprintSpellList GetSpellList(SpellList spellListData)
        {
            Mod.Log($"Creating spell list from JSON data {spellListData.Guid}");

            BlueprintSpellList spellList = _spellbookFactory.CreateSpellList(
                spellListData.Name, spellListData.Guid, spellListData.Level);

            // cantrips are at level 0, therefore we need to go from 0 to the last level
            for (int i = 0; i <= spellListData.Level; i++)
            {
                foreach (var spellId in spellListData.SpellsByLevel[i])
                {
                    BlueprintAbility spell = getSpell(spellId);
                    spellList.SpellsByLevel[i].Spells.Add(spell);
                }
            }

            Mod.Log("DONE: Creating spell list");
            return spellList;
        }

        private static BlueprintAbility getSpell(string value) =>
            SpellbookRepository.GetSpell(IdentifierLookup.INSTANCE.lookupSpell(value));
    }
}
