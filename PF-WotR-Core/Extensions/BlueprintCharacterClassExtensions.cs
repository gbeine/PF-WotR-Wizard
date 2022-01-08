using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.RuleSystem;
using Harmony = PF_WotR_Core.Facades.Harmony;

namespace PF_WotR_Core.Extensions
{
    public static class BlueprintCharacterClassExtensions
    {
        internal static DiceType GetHitDie(this BlueprintCharacterClass blueprintCharacterClass)
        {
            return blueprintCharacterClass_HitDie(blueprintCharacterClass);
        }

        internal static void SetHitDie(this BlueprintCharacterClass blueprintCharacterClass, DiceType hitDie)
        {
            blueprintCharacterClass_set_HitDie(blueprintCharacterClass, hitDie);
        }

        internal static void SetDifficulty(this BlueprintCharacterClass blueprintCharacterClass, int difficulty)
        {
            blueprintCharacterClass_set_Difficulty(blueprintCharacterClass, difficulty);
        }

        internal static void SetSignatureAbilities(this BlueprintCharacterClass blueprintCharacterClass, List<BlueprintFeature> features)
        {
            BlueprintFeatureReference[] featureReferences = features
                .Select(f => f.ToReference<BlueprintFeatureReference>())
                .ToArray();

            blueprintCharacterClass_set_SignatureAbilities(blueprintCharacterClass, featureReferences);
        }
        internal static void SetSignatureAbilities(this BlueprintCharacterClass blueprintCharacterClass, BlueprintFeatureReference[] featureReferences)
        {
            blueprintCharacterClass_set_SignatureAbilities(blueprintCharacterClass, featureReferences);
        }

        internal static void SetBaseAttackBonus(this BlueprintCharacterClass blueprintCharacterClass, BlueprintStatProgression baseAttackBonus)
        {
            blueprintCharacterClass_set_BaseAttackBonus(blueprintCharacterClass, baseAttackBonus.ToReference<BlueprintStatProgressionReference>());
        }

        internal static void SetFortitudeSave(this BlueprintCharacterClass blueprintCharacterClass, BlueprintStatProgression fortitudeSave)
        {
            blueprintCharacterClass_set_FortitudeSave(blueprintCharacterClass, fortitudeSave.ToReference<BlueprintStatProgressionReference>());
        }
        
        internal static void SetWillSave(this BlueprintCharacterClass blueprintCharacterClass, BlueprintStatProgression willSave)
        {
            blueprintCharacterClass_set_WillSave(blueprintCharacterClass, willSave.ToReference<BlueprintStatProgressionReference>());
        }
        internal static void SetReflexSave(this BlueprintCharacterClass blueprintCharacterClass, BlueprintStatProgression reflexSave)
        {
            blueprintCharacterClass_set_ReflexSave(blueprintCharacterClass, reflexSave.ToReference<BlueprintStatProgressionReference>());
        }

        internal static void SetProgression(this BlueprintCharacterClass blueprintCharacterClass, BlueprintProgression progression)
        {
            blueprintCharacterClass_set_Progression(blueprintCharacterClass, progression.ToReference<BlueprintProgressionReference>());
        }

        internal static void SetSpellbook(this BlueprintCharacterClass blueprintCharacterClass, BlueprintSpellbook spellbook)
        {
            blueprintCharacterClass_set_Spellbook(blueprintCharacterClass, spellbook.ToReference<BlueprintSpellbookReference>());
        }

        internal static void SetArchetypes(this BlueprintCharacterClass blueprintCharacterClass, IEnumerable<BlueprintArchetype> archetypes)
        {
            BlueprintArchetypeReference[] archetypeReferences = archetypes
                .Select(f => f.ToReference<BlueprintArchetypeReference>())
                .ToArray();

            blueprintCharacterClass_set_Archetypes(blueprintCharacterClass, archetypeReferences);
        }

        internal static void SetStartingItemsFrom(this BlueprintCharacterClass blueprintCharacterClass, BlueprintCharacterClass source)
        {
            blueprintCharacterClass_set_StartingItems(blueprintCharacterClass, source.StartingItems);
        }

        internal static void SetEquipmentEntitiesFrom(this BlueprintCharacterClass blueprintCharacterClass, BlueprintCharacterClass source)
        {
            blueprintCharacterClass_set_EquipmentEntities(blueprintCharacterClass, source.EquipmentEntities);
        }
        
        internal static BlueprintCharacterClass Clone(this BlueprintCharacterClass clone,
            BlueprintCharacterClass original)
        {
            clone.m_Icon = original.m_Icon;

            clone.LocalizedName = original.LocalizedName;
            clone.LocalizedDescription = original.LocalizedDescription;
            clone.LocalizedDescriptionShort = original.LocalizedDescriptionShort;
            clone.SetDifficulty(original.Difficulty);
            clone.SetSignatureAbilities(original.SignatureAbilities);

            clone.SetStartingItemsFrom(original);
            clone.SetEquipmentEntitiesFrom(original);
            clone.MaleEquipmentEntities = original.MaleEquipmentEntities;
            clone.FemaleEquipmentEntities = original.FemaleEquipmentEntities;

            clone.PrimaryColor = original.PrimaryColor;
            clone.SecondaryColor = original.SecondaryColor;

            clone.SkillPoints = original.SkillPoints;
            clone.SetHitDie(original.GetHitDie());
            clone.SetBaseAttackBonus(original.BaseAttackBonus);
            clone.SetFortitudeSave(original.FortitudeSave);
            clone.SetWillSave(original.WillSave);
            clone.SetReflexSave(original.ReflexSave);
            clone.StartingGold = original.StartingGold;

            clone.IsDivineCaster = original.IsDivineCaster;
            clone.IsArcaneCaster = original.IsArcaneCaster;
            clone.ClassSkills.AddRangeToArray(original.ClassSkills);
            clone.RecommendedAttributes.AddRangeToArray(original.RecommendedAttributes);
            clone.NotRecommendedAttributes.AddRangeToArray(original.NotRecommendedAttributes);

            clone.SetProgression(original.Progression);
            clone.SetSpellbook(original.Spellbook);
            clone.ComponentsArray.AddRangeToArray(original.ComponentsArray);

            return clone;
        }

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintArchetypeReference[]> blueprintCharacterClass_set_Archetypes =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintArchetypeReference[]>("m_Archetypes");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintItemReference[]> blueprintCharacterClass_set_StartingItems =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintItemReference[]>("m_StartingItems");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, KingmakerEquipmentEntityReference[]> blueprintCharacterClass_set_EquipmentEntities =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, KingmakerEquipmentEntityReference[]>("m_EquipmentEntities");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintProgressionReference> blueprintCharacterClass_set_Progression =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintProgressionReference>("m_Progression");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintSpellbookReference> blueprintCharacterClass_set_Spellbook =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintSpellbookReference>("m_Spellbook");
        
        private static readonly Harmony.FastSetter<BlueprintCharacterClass, int> blueprintCharacterClass_set_Difficulty =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, int>("m_Difficulty");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintFeatureReference[]> blueprintCharacterClass_set_SignatureAbilities =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintFeatureReference[]>("m_SignatureAbilities");

        // HitDie
        private static readonly Harmony.FastRef<BlueprintCharacterClass, DiceType> blueprintCharacterClass_HitDie =
            Harmony.CreateFieldGetter<BlueprintCharacterClass, DiceType>("HitDie");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, DiceType> blueprintCharacterClass_set_HitDie =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, DiceType>("HitDie");
        
        // BaseAttackBonus
        private static readonly Harmony.FastRef<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_BaseAttackBonus =
            Harmony.CreateFieldGetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_BaseAttackBonus");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_set_BaseAttackBonus =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_BaseAttackBonus");

        // FortitudeSave
        private static readonly Harmony.FastRef<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_FortitudeSave =
            Harmony.CreateFieldGetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_FortitudeSave");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_set_FortitudeSave =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_FortitudeSave");

        // WillSave
        private static readonly Harmony.FastRef<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_WillSave =
            Harmony.CreateFieldGetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_WillSave");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_set_WillSave =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_WillSave");

        // ReflexSave
        private static readonly Harmony.FastRef<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_ReflexSave =
            Harmony.CreateFieldGetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_ReflexSave");

        private static readonly Harmony.FastSetter<BlueprintCharacterClass, BlueprintStatProgressionReference> blueprintCharacterClass_set_ReflexSave =
            Harmony.CreateFieldSetter<BlueprintCharacterClass, BlueprintStatProgressionReference>("m_ReflexSave");
    }
}
