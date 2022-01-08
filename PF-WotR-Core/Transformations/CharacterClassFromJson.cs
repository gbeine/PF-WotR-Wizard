using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Localization;
using Kingmaker.Utility;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Factories;
using PF_WotR_Core.Identifier;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class CharacterClassFromJson : JsonTransformation
    {
        private static readonly CharacterClassFactory _classFactory = new CharacterClassFactory();
        private static readonly LocalizationFactory _localizationFactory = new LocalizationFactory();

        public static BlueprintCharacterClass CreateBlueprintCharacterClass(CharacterClass characterClassData)
        {
            Mod.Log($"Creating character class from JSON data {characterClassData.Guid}");

            BlueprintCharacterClass characterClass;
            if (!string.Empty.Equals(characterClassData.From))
                characterClass = _classFactory.CreateClassFrom(
                    characterClassData.Name, characterClassData.Guid,
                    IdentifierLookup.INSTANCE.lookupCharacterClass(characterClassData.From));
            else
                characterClass = _classFactory.CreateClass(
                    characterClassData.Name,  characterClassData.Guid);
            
            // characterClass.m_Icon = SpriteLookup.lookupFor(characterClassData.Icon);

            if (!string.Empty.Equals(characterClassData.DisplayName))
                characterClass.LocalizedName = _localizationFactory.CreateString(
                    $"{characterClass.name}.Name",
                    characterClassData.DisplayName);
            if (!string.Empty.Equals(characterClassData.Description))
                characterClass.LocalizedDescription = _localizationFactory.CreateString(
                    $"{characterClass.name}.Description",
                    characterClassData.Description);
            if (!string.Empty.Equals(characterClassData.ShortDescription))
                characterClass.LocalizedDescriptionShort = _localizationFactory.CreateString(
                    $"{characterClass.name}.DescriptionShort",
                    characterClassData.ShortDescription);
            if (characterClassData.Difficulty.HasValue)
                characterClass.SetDifficulty(characterClassData.Difficulty.Value);
            if (characterClassData.SignatureAbilities.Count > 0)
            {
                List<BlueprintFeature> features = new List<BlueprintFeature>();
                foreach (var feature in characterClassData.SignatureAbilities)
                {
                    features.Add(getFeature(feature));
                }

                characterClass.SetSignatureAbilities(features);
            }

            if (!string.Empty.Equals(characterClassData.StartingItems))
                characterClass.SetStartingItemsFrom(getCharacterClass(characterClassData.StartingItems));
            if (!string.Empty.Equals(characterClassData.EquipmentEntities))
                characterClass.SetEquipmentEntitiesFrom(getCharacterClass(characterClassData.EquipmentEntities));
            if (!string.Empty.Equals(characterClassData.MaleEquipmentEntities))
                characterClass.MaleEquipmentEntities = getCharacterClass(characterClassData.MaleEquipmentEntities).MaleEquipmentEntities;
            if (!string.Empty.Equals(characterClassData.FemaleEquipmentEntities))
                characterClass.FemaleEquipmentEntities = getCharacterClass(characterClassData.FemaleEquipmentEntities).FemaleEquipmentEntities;

            if (characterClassData.PrimaryColor.HasValue)
                characterClass.PrimaryColor = characterClassData.PrimaryColor.Value;
            if (characterClassData.SecondaryColor.HasValue)
                characterClass.SecondaryColor = characterClassData.SecondaryColor.Value;

            if (characterClassData.SkillPoints.HasValue)
                characterClass.SkillPoints = characterClassData.SkillPoints.Value;
            if (!string.Empty.Equals(characterClassData.HitDie))
                characterClass.SetHitDie(EnumParser.parseDiceType(characterClassData.HitDie));
            if (!string.Empty.Equals(characterClassData.BaseAttackBonus))
                characterClass.SetBaseAttackBonus(getStatProgression(characterClassData.BaseAttackBonus));
            if (!string.Empty.Equals(characterClassData.FortitudeSave))
                characterClass.SetFortitudeSave(getStatProgression(characterClassData.FortitudeSave));
            if (!string.Empty.Equals(characterClassData.WillSave))
                characterClass.SetWillSave(getStatProgression(characterClassData.WillSave));
            if (!string.Empty.Equals(characterClassData.ReflexSave))
                characterClass.SetReflexSave(getStatProgression(characterClassData.ReflexSave));
            if (characterClassData.StartingGold.HasValue)
                characterClass.StartingGold = characterClassData.StartingGold.Value;

            if (characterClassData.IsArcaneCaster.HasValue)
                characterClass.IsArcaneCaster = characterClassData.IsArcaneCaster.Value;
            if (characterClassData.IsDivineCaster.HasValue)
                characterClass.IsDivineCaster = characterClassData.IsDivineCaster.Value;
            if (characterClassData.ClassSkills.Count > 0)
                characterClass.ClassSkills =
                    characterClassData.ClassSkills
                        .Select(skill => EnumParser.parseStatType(skill)).ToArray();
            if (characterClassData.RecommendedAttributes.Count > 0)
                characterClass.RecommendedAttributes =
                    characterClassData.RecommendedAttributes
                        .Select(skill => EnumParser.parseStatType(skill)).ToArray();
            if (characterClassData.NotRecommendedAttributes.Count > 0)
                characterClass.NotRecommendedAttributes =
                    characterClassData.NotRecommendedAttributes
                        .Select(skill => EnumParser.parseStatType(skill)).ToArray();

            if (!string.Empty.Equals(characterClassData.ProgressionFrom))
                characterClass.SetProgression(getCharacterClass(characterClassData.ProgressionFrom).Progression);
            else if (characterClassData.Progression != null)
            {
                BlueprintProgression progression = ProgressionFromJson.CreateBlueprintProgression(characterClassData.Progression);
                progression.SetClass(characterClass);
                characterClass.SetProgression(progression);
            }

            if (!string.Empty.Equals(characterClassData.SpellbookFrom))
                characterClass.SetSpellbook(getCharacterClass(characterClassData.SpellbookFrom).Spellbook);
            else if (characterClassData.Spellbook != null)
            {
                BlueprintSpellbook spellbook = SpellbookFromJson.CreateBlueprintSpellbook(characterClassData.Spellbook);
                spellbook.SetCharacterClass(characterClass);
                characterClass.SetSpellbook(spellbook);
            }

            if (characterClassData.Archetypes.Count > 0)
            {
                List<BlueprintArchetype> archetypes = new List<BlueprintArchetype>();
                foreach (var archetype in characterClassData.Archetypes)
                {
                    BlueprintArchetype blueprintArchetype = ArchetypeFromJson.CreateBlueprintArchetype(archetype);
                    blueprintArchetype.SetParentClass(characterClass);
                    archetypes.Add(blueprintArchetype);
                }
                characterClass.SetArchetypes(archetypes);
            }

            if (!string.Empty.Equals(characterClassData.ComponentsFrom))
                characterClass.ComponentsArray = getCharacterClass(characterClassData.ComponentsFrom).ComponentsArray;
            else if (characterClassData.ComponentsArray.Count > 0)
            {
                List<BlueprintComponent> components = new List<BlueprintComponent>();
                foreach (var component in characterClassData.ComponentsArray)
                {
                    BlueprintComponent blueprintComponent = ComponentFromJson.CreateBlueprintComponent(component);
                    components.Add(blueprintComponent);
                }

                characterClass.ComponentsArray = components.ToArray();
            }
            
            return characterClass;
        }

        private static BlueprintCharacterClass getCharacterClass(string value) =>
            CharacterClassesRepository.Get(IdentifierLookup.INSTANCE.lookupCharacterClass(value));

        private static BlueprintFeature getFeature(string value) =>
            FeaturesRepository.Get(IdentifierLookup.INSTANCE.lookupFeature(value));
        private static BlueprintStatProgression getStatProgression(string value) =>
            StatProgressionRepository.Get(IdentifierLookup.INSTANCE.lookupStatProgression(value));
    }
}
