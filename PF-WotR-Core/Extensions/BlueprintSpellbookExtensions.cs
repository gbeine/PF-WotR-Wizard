using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Localization;
using PF_WotR_Core.Facades;
using PF_WotR_Core.Factories;

namespace PF_WotR_Core.Extensions
{
    public static class BlueprintSpellbookExtensions
    {

        internal static BlueprintSpellbook Clone(this BlueprintSpellbook clone, BlueprintSpellbook original)
        {
            clone.Name = original.Name;
            clone.SetCharacterClass(original.CharacterClass);
            clone.Spontaneous = original.Spontaneous;
            clone.IsArcane = original.IsArcane;
            clone.CanCopyScrolls = original.CanCopyScrolls;
            clone.AllSpellsKnown = original.AllSpellsKnown;
            clone.CastingAttribute = original.CastingAttribute;
            clone.SpellsPerLevel = original.SpellsPerLevel;
            clone.CasterLevelModifier = original.CasterLevelModifier;
            clone.CantripsType = original.CantripsType;
            clone.SetSpellList(original.SpellList);
            clone.SetSpellsPerDay(original.SpellsPerDay);
            clone.SetSpellsKnown(original.SpellsKnown);
            
            return clone;
        }

        internal static void SetCharacterClass(this BlueprintSpellbook blueprintSpellbook, BlueprintCharacterClass characterClass)
        {
            blueprintSpellbook_set_CharacterClass(blueprintSpellbook, characterClass.ToReference<BlueprintCharacterClassReference>());
        }

        public static void SetSpellList(this BlueprintSpellbook blueprintSpellbook, BlueprintSpellList spellList)
        {
            blueprintSpellbook_set_SpellList(blueprintSpellbook, spellList.ToReference<BlueprintSpellListReference>());
        }

        public static void SetSpellsPerDay(this BlueprintSpellbook blueprintSpellbook, BlueprintSpellsTable spellsPerDay)
        {
            blueprintSpellbook_set_SpellsPerDay(blueprintSpellbook, spellsPerDay.ToReference<BlueprintSpellsTableReference>());
        }

        public static void SetSpellsKnown(this BlueprintSpellbook blueprintSpellbook, BlueprintSpellsTable spellsKnown)
        {
            blueprintSpellbook_set_SpellsKnown(blueprintSpellbook, spellsKnown.ToReference<BlueprintSpellsTableReference>());
        }

        private static readonly Harmony.FastSetter<BlueprintSpellbook, BlueprintCharacterClassReference> blueprintSpellbook_set_CharacterClass =
            Harmony.CreateFieldSetter<BlueprintSpellbook, BlueprintCharacterClassReference>("m_CharacterClass");

        private static readonly Harmony.FastSetter<BlueprintSpellbook, BlueprintSpellListReference> blueprintSpellbook_set_SpellList =
            Harmony.CreateFieldSetter<BlueprintSpellbook, BlueprintSpellListReference>("m_SpellList");

        private static readonly Harmony.FastSetter<BlueprintSpellbook, BlueprintSpellsTableReference> blueprintSpellbook_set_SpellsPerDay =
            Harmony.CreateFieldSetter<BlueprintSpellbook, BlueprintSpellsTableReference>("m_SpellsPerDay");

        private static readonly Harmony.FastSetter<BlueprintSpellbook, BlueprintSpellsTableReference> blueprintSpellbook_set_SpellsKnown =
            Harmony.CreateFieldSetter<BlueprintSpellbook, BlueprintSpellsTableReference>("m_SpellsKnown");

    }
}