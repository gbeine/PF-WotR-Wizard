using System;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.View.Animation;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class EnumParser
    {
        internal static AbilityEffectOnUnit parseAbilityEffectOnUnit(String value)
        {
            Mod.Log($"Parsing AbilityEffectOnUnit from {value}");
            AbilityEffectOnUnit abilityEffectOnUnit;
            if (Enum.TryParse(value, out abilityEffectOnUnit))
            {
                return abilityEffectOnUnit;
            }

            throw new InvalidOperationException($"Cannot parse AbilityEffectOnUnit {value}");
        }
        internal static AbilityRange parseAbilityRange(String value)
        {
            Mod.Log($"Parsing AbilityRange from {value}");
            AbilityRange abilityRange;
            if (Enum.TryParse(value, out abilityRange))
            {
                return abilityRange;
            }

            throw new InvalidOperationException($"Cannot parse AbilityRange {value}");
        }

        internal static AbilityRankType parseAbilityRankType(String value)
        {
            Mod.Log($"Parsing AbilityRankType from {value}");
            AbilityRankType abilityRankType;
            if (Enum.TryParse(value, out abilityRankType))
            {
                return abilityRankType;
            }

            throw new InvalidOperationException($"Cannot parse AbilityRankType {value}");
        }

        internal static AbilitySpawnFxAnchor parseAbilitySpawnFxAnchor(String value)
        {
            Mod.Log($"Parsing AbilitySpawnFxAnchor from {value}");
            AbilitySpawnFxAnchor abilitySpawnFxAnchor;
            if (Enum.TryParse(value, out abilitySpawnFxAnchor))
            {
                return abilitySpawnFxAnchor;
            }

            throw new InvalidOperationException($"Cannot parse AbilitySpawnFxAnchor {value}");
        }

        internal static AbilityType parseAbilityType(String value)
        {
            Mod.Log($"Parsing AbilityType from {value}");
            AbilityType abilityType;
            if (Enum.TryParse(value, out abilityType))
            {
                return abilityType;
            }

            throw new InvalidOperationException($"Cannot parse AbilityType {value}");
        }

        internal static AlignmentMaskType parseAlignment(String value)
        {
            Mod.Log($"Parsing AlignmentMaskType from {value}");
            AlignmentMaskType alignment;
            if (Enum.TryParse(value, out alignment))
            {
                return alignment;
            }

            throw new InvalidOperationException($"Cannot parse AlignmentMaskType {value}");
        }

        internal static ArmorProficiencyGroup parseArmorProficiency(String value)
        {
            Mod.Log($"Parsing ArmorProficiencyGroup from {value}");
            ArmorProficiencyGroup armorProficiency;
            if (Enum.TryParse(value, out armorProficiency))
            {
                return armorProficiency;
            }

            throw new InvalidOperationException($"Cannot parse ArmorProficiencyGroup {value}");
        }

        internal static CantripsType parseCantripsType(String value)
        {
            Mod.Log($"Parsing CantripsType from {value}");
            if ("Orisons".Equals(value)) // this is a fix for the typo in the enum - hahahahaha
                value = "Orisions";
            CantripsType cantripsType;
            if (Enum.TryParse(value, out cantripsType))
            {
                return cantripsType;
            }

            throw new InvalidOperationException($"Cannot parse CantripsType {value}");
        }

        internal static CastAnimationStyle parseCastAnimationStyle(String value)
        {
            Mod.Log($"Parsing CastAnimationStyle from {value}");
            CastAnimationStyle castAnimationStyle;
            if (Enum.TryParse(value, out castAnimationStyle))
            {
                return castAnimationStyle;
            }

            throw new InvalidOperationException($"Cannot parse CastAnimationStyle {value}");
        }

        internal static UnitAnimationActionCastSpell.CastAnimationStyle parseCastAnimation(String value)
        {
            Mod.Log($"Parsing UnitAnimationActionCastSpell.CastAnimationStyle from {value}");
            UnitAnimationActionCastSpell.CastAnimationStyle castAnimationStyle;
            if (Enum.TryParse(value, out castAnimationStyle))
            {
                return castAnimationStyle;
            }

            throw new InvalidOperationException($"Cannot parse UnitAnimationActionCastSpell.CastAnimationStyle {value}");
        }

        internal static UnitCommand.CommandType parseCommandType(String value)
        {
            Mod.Log($"Parsing CommandType from {value}");
            UnitCommand.CommandType commandType;
            if (Enum.TryParse(value, out commandType))
            {
                return commandType;
            }

            throw new InvalidOperationException($"Cannot parse CommandType {value}");
        }

        internal static Concealment parseConcealment(String value)
        {
            Mod.Log($"Parsing Concealment from {value}");
            Concealment concealment;
            if (Enum.TryParse(value, out concealment))
            {
                return concealment;
            }

            throw new InvalidOperationException($"Cannot parse Concealment {value}");
        }

        internal static ConcealmentDescriptor parseConcealmentDescriptor(String value)
        {
            Mod.Log($"Parsing ConcealmentDescriptor from {value}");
            ConcealmentDescriptor concealmentDescriptor;
            if (Enum.TryParse(value, out concealmentDescriptor))
            {
                return concealmentDescriptor;
            }

            throw new InvalidOperationException($"Cannot parse ConcealmentDescriptor {value}");
        }

        internal static ContextRankBaseValueType parseContextRankBaseValueType(String value)
        {
            Mod.Log($"Parsing ContextRankBaseValueType from {value}");
            ContextRankBaseValueType contextRankBaseValueType;
            if (Enum.TryParse(value, out contextRankBaseValueType))
            {
                return contextRankBaseValueType;
            }

            throw new InvalidOperationException($"Cannot parse ContextRankBaseValueType {value}");
        }

        internal static ContextRankProgression parseContextRankProgression(String value)
        {
            Mod.Log($"Parsing ContextRankProgression from {value}");
            ContextRankProgression contextRankProgression;
            if (Enum.TryParse(value, out contextRankProgression))
            {
                return contextRankProgression;
            }

            throw new InvalidOperationException($"Cannot parse ContextRankProgression {value}");
        }

        internal static DamageEnergyType parseDamageEnergyType(String value)
        {
            Mod.Log($"Parsing DamageEnergyType from {value}");
            DamageEnergyType damageEnergyType;
            if (Enum.TryParse(value, out damageEnergyType))
            {
                return damageEnergyType;
            }

            throw new InvalidOperationException($"Cannot parse DamageEnergyType {value}");
        }

        internal static DiceType parseDiceType(String value)
        {
            Mod.Log($"Parsing DiceType from {value}");
            DiceType diceType;
            if (Enum.TryParse(value, out diceType))
            {
                return diceType;
            }

            throw new InvalidOperationException($"Cannot parse DiceType {value}");
        }

        internal static DurationRate parseDurationRate(String value)
        {
            Mod.Log($"Parsing DurationRate from {value}");
            DurationRate durationRate;
            if (Enum.TryParse(value, out durationRate))
            {
                return durationRate;
            }

            throw new InvalidOperationException($"Cannot parse DurationRate {value}");
        }

        internal static FeatureGroup parseFeatureGroup(String value)
        {
            Mod.Log($"Parsing FeatureGroup from {value}");
            FeatureGroup featureGroup;
            if (Enum.TryParse(value, out featureGroup))
            {
                return featureGroup;
            }

            throw new InvalidOperationException($"Cannot parse FeatureGroup {value}");
        }

        internal static AddMechanicsFeature.MechanicsFeatureType parseMechanicsFeatureType(String value)
        {
            Mod.Log($"Parsing MechanicsFeatureType from {value}");
            AddMechanicsFeature.MechanicsFeatureType mechanicsFeatureType;
            if (Enum.TryParse(value, out mechanicsFeatureType))
            {
                return mechanicsFeatureType;
            }

            throw new InvalidOperationException($"Cannot parse MechanicsFeatureType {value}");
        }

        internal static Metamagic parseMetamagic(String value)
        {
            Mod.Log($"Parsing Metamagic from {value}");
            Metamagic spellDescriptor;
            if (Enum.TryParse(value, out spellDescriptor))
            {
                return spellDescriptor;
            }
            throw new InvalidOperationException($"Cannot parse Metamagic {value}");
        }

        internal static ModifierDescriptor parseModifierDescriptor(String value)
        {
            Mod.Log($"Parsing ModifierDescriptor from {value}");
            ModifierDescriptor modifierDescriptor;
            if (Enum.TryParse(value, out modifierDescriptor))
            {
                return modifierDescriptor;
            }

            throw new InvalidOperationException($"Cannot parse ModifierDescriptor {value}");
        }

        internal static Operation parseOperation(String value)
        {
            Mod.Log($"Parsing Operation from {value}");
            Operation operation;
            if (Enum.TryParse(value, out operation))
            {
                return operation;
            }

            throw new InvalidOperationException($"Cannot parse Operation {value}");
        }

        internal static Prerequisite.GroupType parseGroupType(String value)
        {
            Mod.Log($"Parsing GroupType from {value}");
            Prerequisite.GroupType groupType;
            if (Enum.TryParse(value, out groupType))
            {
                return groupType;
            }

            throw new InvalidOperationException($"Cannot parse GroupType {value}");
        }

        internal static SavingThrowType parseSavingThrowType(String value)
        {
            Mod.Log($"Parsing SavingThrowType from {value}");
            SavingThrowType savingThrowType;
            if (Enum.TryParse(value, out savingThrowType))
            {
                return savingThrowType;
            }

            throw new InvalidOperationException($"Cannot parse SavingThrowType {value}");
        }

        internal static SpellDescriptor parseSpellDescriptor(String value)
        {
            Mod.Log($"Parsing SpellDescriptor from {value}");
            SpellDescriptor spellDescriptor;
            if (Enum.TryParse(value, out spellDescriptor))
            {
                return spellDescriptor;
            }
            throw new InvalidOperationException($"Cannot parse SpellDescriptor {value}");
        }

        internal static SpellSchool parseSpellSchool(String value)
        {
            Mod.Log($"Parsing SpellSchool from {value}");
            SpellSchool spellSchool;
            if (Enum.TryParse(value, out spellSchool))
            {
                return spellSchool;
            }

            throw new InvalidOperationException($"Cannot parse SpellSchool {value}");
        }

        internal static StackingType parseStackingType(String value)
        {
            Mod.Log($"Parsing StackingType from {value}");
            StackingType stackingType;
            if (Enum.TryParse(value, out stackingType))
            {
                return stackingType;
            }

            throw new InvalidOperationException($"Cannot parse StackingType {value}");
        }

        internal static StatType parseStatType(String value)
        {
            Mod.Log($"Parsing StatType from {value}");
            StatType statType;
            if (Enum.TryParse(value, out statType))
            {
                return statType;
            }
            if (Enum.TryParse($"Skill{value}", out statType))
            {
                return statType;
            }

            throw new InvalidOperationException($"Cannot parse StatType {value}");
        }

        internal static UnitCondition parseUnitCondition(String value)
        {
            Mod.Log($"Parsing UnitCondition from {value}");
            UnitCondition unitCondition;
            if (Enum.TryParse(value, out unitCondition))
            {
                return unitCondition;
            }

            throw new InvalidOperationException($"Cannot parse UnitCondition type {value}");
        }

        internal static WeaponCategory parseWeaponCategory(String value)
        {
            Mod.Log($"Parsing WeaponCategory from {value}");
            WeaponCategory weaponCategory;
            if (Enum.TryParse(value, out weaponCategory))
            {
                return weaponCategory;
            }

            throw new InvalidOperationException($"Cannot parse WeaponCategory {value}");
        }
    }
}
