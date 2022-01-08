using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Extensions
{
    public static class BlueprintArchetypeExtensions
    {
        internal static void SetBaseAttackBonus(this BlueprintArchetype blueprintArchetype, BlueprintStatProgression baseAttackBonus)
        {
            blueprintArchetype_set_BaseAttackBonus(blueprintArchetype, baseAttackBonus.ToReference<BlueprintStatProgressionReference>());
        }

        internal static void SetFortitudeSave(this BlueprintArchetype blueprintArchetype, BlueprintStatProgression fortitudeSave)
        {
            blueprintArchetype_set_FortitudeSave(blueprintArchetype, fortitudeSave.ToReference<BlueprintStatProgressionReference>());
        }
        
        internal static void SetWillSave(this BlueprintArchetype blueprintArchetype, BlueprintStatProgression willSave)
        {
            blueprintArchetype_set_WillSave(blueprintArchetype, willSave.ToReference<BlueprintStatProgressionReference>());
        }
        internal static void SetReflexSave(this BlueprintArchetype blueprintArchetype, BlueprintStatProgression reflexSave)
        {
            blueprintArchetype_set_ReflexSave(blueprintArchetype, reflexSave.ToReference<BlueprintStatProgressionReference>());
        }

        internal static void SetSpellbook(this BlueprintArchetype blueprintArchetype, BlueprintSpellbook spellbook)
        {
            blueprintArchetype_set_Spellbook(blueprintArchetype, spellbook.ToReference<BlueprintSpellbookReference>());
        }

        internal static void SetParentClass(this BlueprintArchetype blueprintArchetype, BlueprintCharacterClass blueprintCharacterClass)
        {
            blueprintArchetype_set_ParentClass(blueprintArchetype, blueprintCharacterClass);
        }

        private static readonly Harmony.FastRef<BlueprintArchetype, BlueprintItemReference[]> blueprintArchetype_StartingItems =
            Harmony.CreateFieldGetter<BlueprintArchetype, BlueprintItemReference[]>("m_StartingItems");

        private static readonly Harmony.FastSetter<BlueprintArchetype, BlueprintSpellbookReference> blueprintArchetype_set_Spellbook =
            Harmony.CreateFieldSetter<BlueprintArchetype, BlueprintSpellbookReference>("m_ReplaceSpellbook");

        private static readonly Harmony.FastSetter<BlueprintArchetype, BlueprintCharacterClass> blueprintArchetype_set_ParentClass =
            Harmony.CreateFieldSetter<BlueprintArchetype, BlueprintCharacterClass>("m_ParentClass");

        // BaseAttackBonus
        private static readonly Harmony.FastSetter<BlueprintArchetype, BlueprintStatProgressionReference> blueprintArchetype_set_BaseAttackBonus =
            Harmony.CreateFieldSetter<BlueprintArchetype, BlueprintStatProgressionReference>("m_BaseAttackBonus");

        // FortitudeSave
        private static readonly Harmony.FastSetter<BlueprintArchetype, BlueprintStatProgressionReference> blueprintArchetype_set_FortitudeSave =
            Harmony.CreateFieldSetter<BlueprintArchetype, BlueprintStatProgressionReference>("m_FortitudeSave");

        // WillSave
        private static readonly Harmony.FastSetter<BlueprintArchetype, BlueprintStatProgressionReference> blueprintArchetype_set_WillSave =
            Harmony.CreateFieldSetter<BlueprintArchetype, BlueprintStatProgressionReference>("m_WillSave");

        // ReflexSave
        private static readonly Harmony.FastSetter<BlueprintArchetype, BlueprintStatProgressionReference> blueprintArchetype_set_ReflexSave =
            Harmony.CreateFieldSetter<BlueprintArchetype, BlueprintStatProgressionReference>("m_ReflexSave");
 
    }
}