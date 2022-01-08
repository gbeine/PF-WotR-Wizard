using System.Collections.Generic;
using Kingmaker.Blueprints.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Identifier;

namespace PF_WotR_Core.JsonTypes
{
    public class Feature : JsonType
    {
        public Feature(BlueprintFeature blueprintFeature) : base(blueprintFeature)
        {
            string guid = Features.INSTANCE.GetReferenceNameFor(blueprintFeature);
            From = guid;
            Icon = guid;

            DisplayName = blueprintFeature.Name;
            Description = blueprintFeature.Description;

            FeatureGroups = new List<string>();
            foreach (var featureGroup in blueprintFeature.Groups)
            {
                FeatureGroups.Add(featureGroup.ToString());
            }

            HideInUI = blueprintFeature.HideInUI;
            IsClassFeature = blueprintFeature.IsClassFeature;
            ReapplyOnLevelUp = blueprintFeature.ReapplyOnLevelUp;

            ComponentsArray = new List<Component>();
            foreach (var blueprintComponent in blueprintFeature.ComponentsArray)
            {
                ComponentsArray.Add(new Component(blueprintComponent));
            }
        }
        
        public Feature(JObject jObject) : base(jObject)
        {
            From = SelectString(jObject, "From");
            Icon = SelectString(jObject, "Icon");
            DisplayName = SelectString(jObject, "DisplayName");
            Description = SelectString(jObject, "Description", DisplayName);
            FeatureGroups = SelectStringList(jObject, "FeatureGroups");
            HideInUI = SelectBool(jObject, "HideInUI");
            IsClassFeature = SelectBool(jObject, "IsClassFeature");
            ReapplyOnLevelUp = SelectBool(jObject, "ReapplyOnLevelUp");
        }

        [JsonProperty("From")]
        public string From { get; }
        [JsonProperty("Icon")]
        public string Icon { get; }
        [JsonProperty("DisplayName")]
        public string DisplayName { get; }
        [JsonProperty("Description")]
        public string Description { get; }
        [JsonProperty("FeatureGroups")]
        public List<string> FeatureGroups { get; }
        [JsonProperty("HideInUI")]
        public bool? HideInUI { get; }
        [JsonProperty("IsClassFeature")]
        public bool? IsClassFeature { get; }
        [JsonProperty("ReapplyOnLevelUp")]
        public bool? ReapplyOnLevelUp { get; }
        [JsonProperty("ComponentsArray")]
        public List<Component> ComponentsArray { get; }
    }
}
