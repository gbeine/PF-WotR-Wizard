using Kingmaker.Blueprints.Classes.Spells;
using PF_WotR_Core.Factories;
using PF_WotR_Core.Identifier;
using PF_WotR_Core.JsonTypes;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class SpellbookFromJson
    {
        private static readonly SpellbookFactory _spellbookFactory = new SpellbookFactory();

        public static BlueprintSpellbook CreateBlueprintSpellbook(Spellbook spellbookData)
        {
            Mod.Log($"Creating spellbook from JSON data {spellbookData.Guid}");

            BlueprintSpellbook spellbook = !string.Empty.Equals(spellbookData.From)
                ? _spellbookFactory.CreateSpellbookFrom(spellbookData.Name, spellbookData.Guid,
                    IdentifierLookup.INSTANCE.lookupSpellbook(spellbookData.From))
                : _spellbookFactory.CreateSpellbook(spellbookData.Name, spellbookData.Guid);

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

            Mod.Log("DONE: Creating spellbook");
            return spellbook;
        }

    }
}