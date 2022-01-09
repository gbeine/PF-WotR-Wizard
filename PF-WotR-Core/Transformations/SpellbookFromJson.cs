using Kingmaker.Blueprints.Classes.Spells;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Factories;
using PF_WotR_Core.Identifier;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class SpellbookFromJson
    {
        private static readonly SpellbookFactory _spellbookFactory = new SpellbookFactory();
        private static readonly LocalizationFactory _localizationFactory = new LocalizationFactory();

        public static BlueprintSpellbook CreateBlueprintSpellbook(Spellbook spellbookData)
        {
            Mod.Log($"Creating spellbook from JSON data {spellbookData.Guid}");

            BlueprintSpellbook spellbook = !string.Empty.Equals(spellbookData.From)
                ? _spellbookFactory.CreateSpellbookFrom(spellbookData.Name, spellbookData.Guid,
                    IdentifierLookup.INSTANCE.lookupSpellbook(spellbookData.From))
                : _spellbookFactory.CreateSpellbook(spellbookData.Name, spellbookData.Guid);

            if (!string.Empty.Equals(spellbookData.DisplayName))
                spellbook.Name = _localizationFactory.CreateString($"{spellbookData.Name}.Name", spellbookData.DisplayName);;

            if (spellbookData.IsSpontaneous.HasValue)
                spellbook.Spontaneous = spellbookData.IsSpontaneous.Value;
            if (spellbookData.IsArcane.HasValue)
                spellbook.IsArcane = spellbookData.IsArcane.Value;
            if (spellbookData.CanCopyScrolls.HasValue)
                spellbook.CanCopyScrolls = spellbookData.CanCopyScrolls.Value;
            if (spellbookData.AllSpellsKnown.HasValue)
                spellbook.AllSpellsKnown = spellbookData.AllSpellsKnown.Value;
            if (spellbookData.AllSpellsKnown.HasValue)
                spellbook.AllSpellsKnown = spellbookData.AllSpellsKnown.Value;
            if (!string.Empty.Equals(spellbookData.CastingAttribute))
                spellbook.CastingAttribute = EnumParser.parseStatType(spellbookData.CastingAttribute);
            if (spellbookData.SpellsPerLevel.HasValue)
                spellbook.SpellsPerLevel = spellbookData.SpellsPerLevel.Value;
            if (spellbookData.CasterLevelModifier.HasValue)
                spellbook.CasterLevelModifier = spellbookData.CasterLevelModifier.Value;
            if (!string.Empty.Equals(spellbookData.Cantrips))
                spellbook.CantripsType = EnumParser.parseCantripsType(spellbookData.Cantrips);

            if (!string.Empty.Equals(spellbookData.SpellListFrom))
                spellbook.SetSpellList(getSpellbook(spellbookData.SpellListFrom).SpellList);
            else if (spellbookData.SpellList != null)
                spellbook.SetSpellList(SpellListFromJson.GetSpellList(spellbookData.SpellList));

            if (!string.Empty.Equals(spellbookData.SpellsKnownFrom))
                spellbook.SetSpellsKnown(getSpellbook(spellbookData.SpellsKnownFrom).SpellsKnown);
            else if (spellbookData.SpellsKnown != null)
                spellbook.SetSpellsKnown(SpellsTableFromJson.GetSpellsTable(spellbookData.SpellsKnown));

            if (!string.Empty.Equals(spellbookData.SpellsPerDayFrom))
                spellbook.SetSpellsPerDay(getSpellbook(spellbookData.SpellsPerDayFrom).SpellsPerDay);
            if (spellbookData.SpellsPerDay != null)
                spellbook.SetSpellsPerDay(SpellsTableFromJson.GetSpellsTable(spellbookData.SpellsPerDay));

            Mod.Log("DONE: Creating spellbook");
            return spellbook;
        }

        private static BlueprintSpellbook getSpellbook(string value) =>
            SpellbookRepository.Get(IdentifierLookup.INSTANCE.lookupSpellbook(value));

    }
}