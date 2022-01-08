using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Identifier;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.JsonTypes
{
    public class Progression : Feature
    {
        public Progression(BlueprintProgression blueprintProgression) : base(blueprintProgression)
        {
            UiDeterminatorsGroup = new List<string>();
            foreach (var blueprintFeatureBase in blueprintProgression.UIDeterminatorsGroup)
            {
                UiDeterminatorsGroup.Add(Features.INSTANCE.GetReferenceNameFor(blueprintFeatureBase));
            }

            UiGroups = Array.Empty<List<string>>().ToList();
            foreach (var uiGroup in blueprintProgression.UIGroups)
            {
                UiGroups.Add(
                    uiGroup.Features
                        .Select(feature => Features.INSTANCE.GetReferenceNameFor(feature))
                        .ToList()
                    );
            }

            LevelEntries = new Dictionary<int, List<string>>();
            foreach (var levelEntry in blueprintProgression.LevelEntries)
            {
                LevelEntries[levelEntry.Level] =
                    levelEntry.Features
                        .Select(feature => Features.INSTANCE.GetReferenceNameFor(feature))
                        .ToList();
            }

            ForAllOtherClasses = blueprintProgression.ForAllOtherClasses;
            GiveFeaturesForPreviousLevels = blueprintProgression.GiveFeaturesForPreviousLevels;
            
            Classes = new List<string>();
            foreach (var characterClass in blueprintProgression.Classes)
            {
                Classes.Add(CharacterClasses.INSTANCE.GetReferenceNameFor(characterClass));
            }
            
        }
        
        public Progression(JObject jObject) : base(jObject)
        {
            UiDeterminatorsGroup = SelectStringList(jObject, "UiDeterminatorsGroup");
            SelectUIGroups(jObject);
            SelectLevelEntries(jObject);
        }

        private void SelectUIGroups(JObject jObject)
        {
            JToken jUiGroups = jObject.SelectToken("UiGroups");
            UiGroups = Array.Empty<List<string>>().ToList();
        
            if (jUiGroups != null)
            {
                foreach (var jUiGroup in jUiGroups.Value<JArray>())
                {
                    UiGroups.Add(jUiGroup.Values<string>().ToList());
                }
            }
        }

        private void SelectLevelEntries(JObject jObject)
        {
            JToken jLevelEntries = jObject.SelectToken("LevelEntries");
            if (jLevelEntries == null)
            {
                LevelEntries = new Dictionary<int, List<string>>();
            }
            else
            {
                LevelEntries = new Dictionary<int, List<string>>();
                for (int i = 1; i < 21; i++)
                {
                    JToken jLevel = jLevelEntries.SelectToken(i.ToString());
                    List<string> levelEntries = jLevel != null
                        ? jLevel.Value<JArray>().Values<string>().ToList()
                        : Array.Empty<String>().ToList();
                    LevelEntries[i] = levelEntries;
                }
            }
        }

        [JsonProperty("UiDeterminatorsGroup")]
        public List<string> UiDeterminatorsGroup { get; }
        [JsonProperty("UiGroups")]
        public List<List<string>> UiGroups { get; private set; }
        [JsonProperty("LevelEntries")]
        public Dictionary<int, List<string>> LevelEntries { get; private set; }

        [JsonProperty("ForAllOtherClasses")]
        public bool? ForAllOtherClasses { get;  }
        [JsonProperty("GiveFeaturesForPreviousLevels")]
        public bool? GiveFeaturesForPreviousLevels { get;  }
        [JsonProperty("Classes")]
        public List<string> Classes { get; }

        public bool HasUiDeterminatorsGroup { get { return UiDeterminatorsGroup.Count > 0; } }
        public bool HasUiGroups { get { return UiGroups.Count > 0; } }
        public bool HasLevelEntries { get { return LevelEntries.Count > 0; } }
    }
}
