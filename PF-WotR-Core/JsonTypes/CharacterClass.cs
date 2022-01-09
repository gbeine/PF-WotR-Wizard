using System.Collections.Generic;
using System.IO;
using System.Linq;
using Kingmaker.Blueprints.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Identifier;


namespace PF_WotR_Core.JsonTypes
{
    public class CharacterClass : JsonType
    {
        public CharacterClass(BlueprintCharacterClass blueprintCharacterClass) : base(blueprintCharacterClass)
        {
            string guid = CharacterClasses.INSTANCE.GetReferenceNameFor(blueprintCharacterClass);
            From = guid;
            Icon = guid;

            DisplayName = blueprintCharacterClass.LocalizedName;
            Description = blueprintCharacterClass.LocalizedDescription;
            ShortDescription = blueprintCharacterClass.LocalizedDescriptionShort;
            Difficulty = blueprintCharacterClass.Difficulty;
            SignatureAbilities = blueprintCharacterClass.SignatureAbilities
                .Select(feature => Features.INSTANCE.GetReferenceNameFor(feature))
                .ToList();
                
            StartingItems = guid;
            EquipmentEntities = guid;
            MaleEquipmentEntities = guid;
            FemaleEquipmentEntities = guid;

            PrimaryColor = blueprintCharacterClass.PrimaryColor;
            SecondaryColor = blueprintCharacterClass.SecondaryColor;

            SkillPoints = blueprintCharacterClass.SkillPoints;
            HitDie = blueprintCharacterClass.GetHitDie().ToString();
            BaseAttackBonus = StatProgession.INSTANCE.GetReferenceNameFor(blueprintCharacterClass.BaseAttackBonus);
            FortitudeSave = StatProgession.INSTANCE.GetReferenceNameFor(blueprintCharacterClass.FortitudeSave);
            WillSave = StatProgession.INSTANCE.GetReferenceNameFor(blueprintCharacterClass.WillSave);
            ReflexSave = StatProgession.INSTANCE.GetReferenceNameFor(blueprintCharacterClass.ReflexSave);
            StartingGold = blueprintCharacterClass.StartingGold;

            IsDivineCaster = blueprintCharacterClass.IsDivineCaster;
            IsArcaneCaster = blueprintCharacterClass.IsArcaneCaster;
            ClassSkills = blueprintCharacterClass.ClassSkills
                .Select(skill => skill.ToString()).ToList();
            RecommendedAttributes = blueprintCharacterClass.RecommendedAttributes
                .Select(attribute => attribute.ToString()).ToList();
            NotRecommendedAttributes = blueprintCharacterClass.NotRecommendedAttributes
                .Select(attribute => attribute.ToString()).ToList();

            ProgressionFrom = guid;
            Progression = new Progression(blueprintCharacterClass.Progression);
            
            if (blueprintCharacterClass.Spellbook != null)
            {
                SpellbookFrom = guid;
                Spellbook = new Spellbook(blueprintCharacterClass.Spellbook);
            }

            ComponentsArray = new List<Component>();
            foreach (var blueprintComponent in blueprintCharacterClass.ComponentsArray)
            {
                ComponentsArray.Add(new Component(blueprintComponent));
            }

            Archetypes = new List<Archetype>();
            foreach (var blueprintArchetype in blueprintCharacterClass.Archetypes)
            {
                Archetypes.Add(new Archetype(blueprintArchetype));
            }
        }

        public CharacterClass(JObject jObject) : base(jObject)
        {
            From = SelectString(jObject, "From");
            Icon = SelectString(jObject, "Icon");

            DisplayName = SelectString(jObject, "DisplayName");
            Description = SelectString(jObject, "Description", DisplayName);
            ShortDescription = SelectString(jObject, "ShortDescription", Description);
            Difficulty = SelectInt(jObject, "Difficulty");
            SignatureAbilities = SelectStringList(jObject, "SignatureAbilities");

            StartingItems = SelectString(jObject, "StartingItems");
            EquipmentEntities = SelectString(jObject, "EquipmentEntities");
            MaleEquipmentEntities = SelectString(jObject, "MaleEquipmentEntities", EquipmentEntities);
            FemaleEquipmentEntities = SelectString(jObject, "FemaleEquipmentEntities", EquipmentEntities);

            PrimaryColor = SelectInt(jObject, "PrimaryColor");
            SecondaryColor = SelectInt(jObject, "SecondaryColor");

            SkillPoints = SelectInt(jObject, "SkillPoints");
            HitDie = SelectString(jObject, "HitDie");
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

            ProgressionFrom = SelectString(jObject, "ProgressionFrom");
            JToken jProgression = jObject.SelectToken("Progression");
            if (jProgression?.Value<JObject>() != null)
            {
                Progression = new Progression(jProgression.Value<JObject>());
            }
            
            SpellbookFrom = SelectString(jObject, "SpellbookFrom");
            JToken jSpellbook = jObject.SelectToken("Spellbook");
            if (jSpellbook?.Value<JObject>() != null)
            {
                Spellbook = new Spellbook(jSpellbook.Value<JObject>());
            }

            ComponentsFrom = SelectString(jObject, "ComponentsFrom");

            JToken jComponents = jObject.SelectToken("ComponentsArray");
            ComponentsArray = new List<Component>();
            if (jComponents?.Value<JArray>() != null)
            {
                foreach (var jComponent in jComponents.Value<JArray>())
                {
                    ComponentsArray.Add(new Component(jComponent.Value<JObject>()));
                }
            }

            JToken jArchetypes = jObject.SelectToken("Archetypes");
            Archetypes = new List<Archetype>(); 
            if (jArchetypes?.Value<JArray>() != null)
            {
                foreach (var jArchetype in jArchetypes.Value<JArray>())
                {
                    Archetypes.Add(new Archetype(jArchetype.Value<JObject>()));
                }
            }

            if (!isValid())
            {
                throw new InvalidDataException(
                    $"Character class {Name} need to define either from or other data fields described.");
            }
        }

        protected new bool isValid()
        {
            return !string.Empty.Equals(From)
                   || (!string.Empty.Equals(Icon)
                      && !string.Empty.Equals(EquipmentEntities)
                      && SkillPoints.HasValue
                      && PrimaryColor.HasValue
                      && SecondaryColor.HasValue);
        }

        [JsonProperty("From")]
        public string From { get; }
        [JsonProperty("Icon")]
        public string Icon { get; }
        [JsonProperty("DisplayName")]
        public string DisplayName { get; }
        [JsonProperty("Description")]
        public string Description { get; }
        [JsonProperty("ShortDescription")]
        public string ShortDescription { get; }
        [JsonProperty("Difficulty")]
        public int? Difficulty { get; }
        [JsonProperty("SignatureAbilities")]
        public List<string> SignatureAbilities { get; }
        [JsonProperty("StartingItems")]
        public string StartingItems { get; }
        [JsonProperty("EquipmentEntities")]
        public string EquipmentEntities { get; }
        [JsonProperty("MaleEquipmentEntities")]
        public string MaleEquipmentEntities { get; }
        [JsonProperty("FemaleEquipmentEntities")]
        public string FemaleEquipmentEntities { get; }
        [JsonProperty("PrimaryColor")]
        public int? PrimaryColor { get; }
        [JsonProperty("SecondaryColor")]
        public int? SecondaryColor { get; }
        [JsonProperty("SkillPoints")]
        public int? SkillPoints { get; }
        [JsonProperty("HitDie")]
        public string HitDie { get; }
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
        [JsonProperty("ProgressionFrom")]
        public string ProgressionFrom { get; }
        [JsonProperty("Progression")]
        public Progression Progression { get; }
        [JsonProperty("SpellbookFrom")]
        public string SpellbookFrom { get; }
        [JsonProperty("Spellbook")]
        public Spellbook Spellbook { get; }
        [JsonProperty("ComponentsFrom")]
        public string ComponentsFrom { get; }
        [JsonProperty("ComponentsArray")]
        public List<Component> ComponentsArray { get; }
        [JsonProperty("Archetypes")]
        public List<Archetype> Archetypes { get; }
    }
}
