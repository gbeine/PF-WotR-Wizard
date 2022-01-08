using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Identifier;

namespace PF_WotR_Core.JsonTypes
{
    public class Archetype : JsonType
    {
        public Archetype(BlueprintArchetype blueprintArchetype) : base(blueprintArchetype)
        {
            string guid = Archetypes.INSTANCE.GetReferenceNameFor(blueprintArchetype);
            From = guid;
            Icon = guid;

            DisplayName = blueprintArchetype.LocalizedName;
            Description = blueprintArchetype.LocalizedDescription;
            
            StartingItems = guid;
            
            BaseAttackBonus = blueprintArchetype.BaseAttackBonus != null 
                ? StatProgession.INSTANCE.GetReferenceNameFor(blueprintArchetype.BaseAttackBonus)
                : null;
            FortitudeSave =  blueprintArchetype.FortitudeSave != null 
                ? StatProgession.INSTANCE.GetReferenceNameFor(blueprintArchetype.FortitudeSave)
                : null;
            WillSave =  blueprintArchetype.WillSave != null 
                ? StatProgession.INSTANCE.GetReferenceNameFor(blueprintArchetype.WillSave)
                : null;
            ReflexSave =  blueprintArchetype.ReflexSave != null 
                ? StatProgession.INSTANCE.GetReferenceNameFor(blueprintArchetype.ReflexSave)
                : null;
            StartingGold = blueprintArchetype.StartingGold;
            
            IsDivineCaster = blueprintArchetype.IsDivineCaster;
            IsArcaneCaster = blueprintArchetype.IsArcaneCaster;
            
            ClassSkills = blueprintArchetype.ClassSkills
                .Select(skill => skill.ToString()).ToList();
            RecommendedAttributes = blueprintArchetype.RecommendedAttributes
                .Select(attribute => attribute.ToString()).ToList();
            NotRecommendedAttributes = blueprintArchetype.NotRecommendedAttributes
                .Select(attribute => attribute.ToString()).ToList();
            
            if (blueprintArchetype.Spellbook != null)
            {
                SpellbookFrom = guid;
                Spellbook = new Spellbook(blueprintArchetype.Spellbook);
            }
            
            AddFeatures = new Dictionary<int, List<string>>();
            foreach (var levelEntry in blueprintArchetype.AddFeatures)
            {
                AddFeatures[levelEntry.Level] =
                    levelEntry.Features
                        .Select(feature => Features.INSTANCE.GetReferenceNameFor(feature))
                        .ToList();
            }
            
            RemoveFeatures = new Dictionary<int, List<string>>();
            foreach (var levelEntry in blueprintArchetype.RemoveFeatures)
            {
                RemoveFeatures[levelEntry.Level] =
                    levelEntry.Features
                        .Select(feature => Features.INSTANCE.GetReferenceNameFor(feature))
                        .ToList();
            }
            
            ComponentsArray = new List<Component>();
            foreach (var blueprintComponent in blueprintArchetype.ComponentsArray)
            {
                ComponentsArray.Add(new Component(blueprintComponent));
            }
        }

        public Archetype(JObject jObject) : base(jObject)
        {
            From = SelectString(jObject, "From");
            Icon = SelectString(jObject, "Icon");

            DisplayName = SelectString(jObject, "DisplayName");
            Description = SelectString(jObject, "Description", DisplayName);

            StartingItems = SelectString(jObject, "StartingItems");
            
            BaseAttackBonus = SelectString(jObject, "BaseAttackBonus");
            FortitudeSave = SelectString(jObject, "FortitudeSave");
            WillSave = SelectString(jObject, "WillSave");
            ReflexSave = SelectString(jObject, "ReflexSave");
            StartingGold = SelectInt(jObject, "StartingGold");

            IsDivineCaster = SelectBool(jObject, "IsDivineCaster");
            IsArcaneCaster = SelectBool(jObject, "IsArcaneCaster");
            ClassSkills = SelectStringList(jObject, "ClassSkills");
            RecommendedAttributes = SelectStringList(jObject, "RecommendedAttributes");
            NotRecommendedAttributes = SelectStringList(jObject, "NotRecommendedAttributes");

            ComponentsFrom = SelectString(jObject, "ComponentsFrom");

            JToken jComponents = jObject.SelectToken("ComponentsArray");
            if (jComponents?.Value<JArray>() != null)
            {
                ComponentsArray = new List<Component>();
                foreach (var jComponent in jComponents.Value<JArray>())
                {
                    ComponentsArray.Add(new Component(jComponent.Value<JObject>()));
                }
            }

            SpellbookFrom = SelectString(jObject, "SpellbookFrom");
            JToken jSpellbook = jObject.SelectToken("Spellbook");
            if (jSpellbook?.Value<JObject>() != null)
            {
                Spellbook = new Spellbook(jSpellbook.Value<JObject>());
            }

            SelectAddFeatures(jObject);
            SelectRemoveFeatures(jObject);
        }

        private void SelectAddFeatures(JObject jObject)
        {
            JToken jAddFeatures = jObject.SelectToken("AddFeatures");
            if (jAddFeatures == null)
            {
                AddFeatures = new Dictionary<int, List<string>>();
            }
            else
            {
                AddFeatures = new Dictionary<int, List<string>>();
                for (int i = 1; i < 21; i++)
                {
                    JToken jLevel = jAddFeatures.SelectToken(i.ToString());
                    List<string> addFeatures = jLevel != null
                        ? jLevel.Value<JArray>().Values<string>().ToList()
                        : Array.Empty<string>().ToList();
                    AddFeatures[i] = addFeatures;
                }
            }
        }

        private void SelectRemoveFeatures(JObject jObject)
        {
            JToken jRemoveFeatures = jObject.SelectToken("RemoveFeatures");
            if (jRemoveFeatures == null)
            {
                RemoveFeatures = new Dictionary<int, List<string>>();
            }
            else
            {
                RemoveFeatures = new Dictionary<int, List<string>>();
                for (int i = 1; i < 21; i++)
                {
                    JToken jLevel = jRemoveFeatures.SelectToken(i.ToString());
                    List<string> removeFeatures = jLevel != null
                        ? jLevel.Value<JArray>().Values<string>().ToList()
                        : Array.Empty<string>().ToList();
                    RemoveFeatures[i] = removeFeatures;
                }
            }
        }
        
        [JsonProperty("From")]
        public string From { get; }
        [JsonProperty("Icon")]
        public string Icon { get; }
        [JsonProperty("DisplayName")]
        public string DisplayName { get; }
        [JsonProperty("Description")]
        public string Description { get; }
        [JsonProperty("StartingItems")]
        public string StartingItems { get; }
        [JsonProperty("BaseAttackBonus")]
        public string BaseAttackBonus { get; }
        [JsonProperty("FortitudeSave")]
        public string FortitudeSave { get; }
        [JsonProperty("WillSave")]
        public string WillSave { get; }
        [JsonProperty("ReflexSave")]
        public string ReflexSave { get; }
        [JsonProperty("StartingGold")]
        public int? StartingGold { get; }
        [JsonProperty("IsDivineCaster")]
        public bool? IsDivineCaster { get; }
        [JsonProperty("IsArcaneCaster")]
        public bool? IsArcaneCaster { get; }
        [JsonProperty("ClassSkills")]
        public List<string> ClassSkills { get; }
        [JsonProperty("RecommendedAttributes")]
        public List<string> RecommendedAttributes { get; }
        [JsonProperty("NotRecommendedAttributes")]
        public List<string> NotRecommendedAttributes { get; }
        [JsonProperty("SpellbookFrom")]
        public string SpellbookFrom { get; }
        [JsonProperty("Spellbook")]
        public Spellbook Spellbook { get; }
        [JsonProperty("AddFeatures")]
        public Dictionary<int, List<string>> AddFeatures { get; private set; }
        [JsonProperty("RemoveFeatures")]
        public Dictionary<int, List<string>> RemoveFeatures { get; private set; }
        [JsonProperty("ComponentsFrom")]
        public string ComponentsFrom { get; }
        [JsonProperty("ComponentsArray")]
        public List<Component> ComponentsArray { get; }
    }
}
