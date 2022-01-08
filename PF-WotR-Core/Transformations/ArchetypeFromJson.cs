using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Factories;
using PF_WotR_Core.Identifier;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class ArchetypeFromJson
    {
        private static readonly ArchetypeFactory _archetypeFactory = new ArchetypeFactory();
        private static readonly LocalizationFactory _localizationFactory = new LocalizationFactory();
        private static readonly LevelEntryFactory _levelEntryFactory = new LevelEntryFactory();

        public static BlueprintArchetype CreateBlueprintArchetype(Archetype archetypeData)
        {
            Mod.Log($"Creating archetypeData from JSON data {archetypeData.Guid}");

            BlueprintArchetype archetype;
            if (!string.Empty.Equals(archetypeData.From))
                archetype = _archetypeFactory.CreateArchetypeFrom(
                    archetypeData.Name, archetypeData.Guid,
                    IdentifierLookup.INSTANCE.lookupArchetype(archetypeData.From));
            else
                archetype = _archetypeFactory.CreateArchetype(
                    archetypeData.Name,  archetypeData.Guid);

            // archetype.m_Icon = SpriteLookup.lookupFor(archetypeData.Icon);

            if (!string.Empty.Equals(archetypeData.DisplayName))
                archetype.LocalizedName = _localizationFactory.CreateString(
                    $"{archetype.name}.Name",
                    archetypeData.DisplayName);
            if (!string.Empty.Equals(archetypeData.Description))
                archetype.LocalizedDescription = _localizationFactory.CreateString(
                    $"{archetype.name}.Description",
                    archetypeData.Description);

            // TODO: implement
            // if (!string.Empty.Equals(archetypeData.StartingItems))
            //     archetype.AddStartingItemsFrom(getCharacterClass(archetypeData.StartingItems));

            if (!string.Empty.Equals(archetypeData.BaseAttackBonus))
                archetype.SetBaseAttackBonus(getStatProgression(archetypeData.BaseAttackBonus));
            if (!string.Empty.Equals(archetypeData.FortitudeSave))
                archetype.SetFortitudeSave(getStatProgression(archetypeData.FortitudeSave));
            if (!string.Empty.Equals(archetypeData.WillSave))
                archetype.SetWillSave(getStatProgression(archetypeData.WillSave));
            if (!string.Empty.Equals(archetypeData.ReflexSave))
                archetype.SetReflexSave(getStatProgression(archetypeData.ReflexSave));
            if (archetypeData.StartingGold.HasValue)
                archetype.StartingGold = archetypeData.StartingGold.Value;

            if (archetypeData.IsArcaneCaster.HasValue)
                archetype.IsArcaneCaster = archetypeData.IsArcaneCaster.Value;
            if (archetypeData.IsDivineCaster.HasValue)
                archetype.IsDivineCaster = archetypeData.IsDivineCaster.Value;
            if (archetypeData.ClassSkills.Count > 0)
                archetype.ClassSkills =
                    archetypeData.ClassSkills
                        .Select(skill => EnumParser.parseStatType(skill)).ToArray();
            if (archetypeData.RecommendedAttributes.Count > 0)
                archetype.RecommendedAttributes =
                    archetypeData.RecommendedAttributes
                        .Select(skill => EnumParser.parseStatType(skill)).ToArray();
            if (archetypeData.NotRecommendedAttributes.Count > 0)
                archetype.NotRecommendedAttributes =
                    archetypeData.NotRecommendedAttributes
                        .Select(skill => EnumParser.parseStatType(skill)).ToArray();

            if (archetypeData.AddFeatures != null)
                archetype.AddFeatures = getAddFeatures(archetypeData).ToArray();

            if (archetypeData.RemoveFeatures != null)
                archetype.RemoveFeatures = getRemoveFeatures(archetypeData).ToArray();

            if (!string.Empty.Equals(archetypeData.SpellbookFrom))
                archetype.SetSpellbook(getCharacterClass(archetypeData.SpellbookFrom).Spellbook);
            else if (archetypeData.Spellbook != null)
                archetype.SetSpellbook(SpellbookFromJson.CreateBlueprintSpellbook(archetypeData.Spellbook));

            if (!string.Empty.Equals(archetypeData.ComponentsFrom))
                archetype.ComponentsArray = getCharacterClass(archetypeData.ComponentsFrom).ComponentsArray;
            else if (archetypeData.ComponentsArray.Count > 0)
            {
                List<BlueprintComponent> components = new List<BlueprintComponent>();
                foreach (var component in archetypeData.ComponentsArray)
                {
                    BlueprintComponent blueprintComponent = ComponentFromJson.CreateBlueprintComponent(component);
                    components.Add(blueprintComponent);
                }

                archetype.ComponentsArray = components.ToArray();
            }

            return archetype;
        }

        private static List<LevelEntry> getAddFeatures(Archetype archetypeData)
        {
            Mod.Log("Creating AddFeatures");
            List<LevelEntry> levelEntries = new List<LevelEntry>();
            int level = 1;
            foreach (var levelEntry in archetypeData.AddFeatures)
            {
                Mod.Log($"Creating LevelEntries for level {level}");
                List<BlueprintFeature> features = new List<BlueprintFeature>();
                foreach (var feature in levelEntry.Value)
                {
                    features.Add(getLevelEntryFeature(feature));
                }
        
                levelEntries.Add(_levelEntryFactory.CreateLevelEntry(level, features));
                Mod.Log($"Done with level {level}");
                level++;
            }
        
            Mod.Log("DONE: Creating LevelEntries");
            return levelEntries;
        }

        private static List<LevelEntry> getRemoveFeatures(Archetype archetypeData)
        {
            Mod.Log("Creating RemoveFeatures");
            List<LevelEntry> levelEntries = new List<LevelEntry>();
            int level = 1;
            foreach (var levelEntry in archetypeData.RemoveFeatures)
            {
                Mod.Log($"Creating LevelEntries for level {level}");
                List<BlueprintFeature> features = new List<BlueprintFeature>();
                foreach (var feature in levelEntry.Value)
                {
                    features.Add(getLevelEntryFeature(feature));
                }
        
                levelEntries.Add(_levelEntryFactory.CreateLevelEntry(level, features));
                Mod.Log($"Done with level {level}");
                level++;
            }
        
            Mod.Log("DONE: Creating LevelEntries");
            return levelEntries;
        }

        private static BlueprintCharacterClass getCharacterClass(string value) =>
            CharacterClassesRepository.Get(IdentifierLookup.INSTANCE.lookupCharacterClass(value));

        private static BlueprintStatProgression getStatProgression(string value) =>
            StatProgressionRepository.Get(IdentifierLookup.INSTANCE.lookupStatProgression(value));
        
        private static BlueprintFeature getLevelEntryFeature(string value) =>
            FeaturesRepository.Get(IdentifierLookup.INSTANCE.lookupFeature(value));
    }
}