using System;
using System.Collections.Generic;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Factories;
using PF_WotR_Core.Identifier;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class ProgressionFromJson : JsonTransformation
    {
        private static readonly ProgressionFactory _progressionFactory = new ProgressionFactory();
        private static readonly UIGroupFactory _uiGroupFactory = new UIGroupFactory();
        private static readonly LevelEntryFactory _levelEntryFactory = new LevelEntryFactory();

        public static BlueprintProgression CreateBlueprintProgression(Progression progressionData)
        {
            Mod.Log($"Creating progression from JSON data {progressionData.Guid}");

            BlueprintProgression progression = !string.Empty.Equals(progressionData.From)
                ? _progressionFactory.CreateProgressionFrom(progressionData.Name, progressionData.Guid,
                    IdentifierLookup.INSTANCE.lookupProgression(progressionData.From))
                : _progressionFactory.CreateProgression(progressionData.Name, progressionData.Guid);

            if (progressionData.HasUiDeterminatorsGroup)
                progression.SetUIDeterminatorsGroup(getUIDeterminatorsGroup(progressionData));
            if (progressionData.HasUiGroups)
                progression.UIGroups = getUIGroups(progressionData).ToArray();
            if (progressionData.HasLevelEntries)
                progression.LevelEntries = getLevelEntries(progressionData).ToArray();

            FeatureFromJson.SetValuesFromData(progression, progressionData);
            
            Mod.Log("DONE: Creating progression");
            return progression;
        }

        private static List<BlueprintFeatureBase> getUIDeterminatorsGroup(Progression progressionData)
        {
            Mod.Log("Creating UIDeterminatorsGroup");
            List<BlueprintFeatureBase> uiDeterminatorsGroup = new List<BlueprintFeatureBase>();
            foreach (var feature in progressionData.UiDeterminatorsGroup)
            {
                uiDeterminatorsGroup.Add(getUiDeterminatorGroupEntry(feature));
            }
        
            Mod.Log("DONE: Creating UIDeterminatorsGroup");
            return uiDeterminatorsGroup;
        }
        
        private static List<UIGroup> getUIGroups(Progression progressionData)
        {
            Mod.Log("Creating UIGroups");
            List<UIGroup> uiGroups = new List<UIGroup>();
            foreach (var group in progressionData.UiGroups)
            {
                List<BlueprintFeature> features = new List<BlueprintFeature>();
                foreach (var feature in @group)
                {
                    features.Add(getUiGroupEntry(feature));
                }
        
                uiGroups.Add(_uiGroupFactory.CreateUIGroup(features.ToArray()));
            }
        
            Mod.Log("DONE: Creating UIGroups");
            return uiGroups;
        }
        
        private static List<LevelEntry> getLevelEntries(Progression progressionData)
        {
            Mod.Log("Creating LevelEntries");
            List<LevelEntry> levelEntries = new List<LevelEntry>();
            int level = 1;
            foreach (var levelEntry in progressionData.LevelEntries)
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
        
        private static BlueprintFeatureBase getUiDeterminatorGroupEntry(string value) =>
            FeaturesRepository.Get(IdentifierLookup.INSTANCE.lookupFeature(value));
        
        private static BlueprintFeature getUiGroupEntry(string value) =>
            FeaturesRepository.Get(IdentifierLookup.INSTANCE.lookupFeature(value));
        
        private static BlueprintFeature getLevelEntryFeature(string value) =>
            FeaturesRepository.Get(IdentifierLookup.INSTANCE.lookupFeature(value));
    }
}
