using System.Collections.Generic;
using JetBrains.Annotations;
using Kingmaker.Blueprints.Classes.Spells;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Identifier;

namespace PF_WotR_Core.JsonTypes
{
    public class Spellbook : JsonType
    {
        public Spellbook(BlueprintSpellbook blueprintSpellbook) : base(blueprintSpellbook)
        {
            string guid = Spellbooks.INSTANCE.GetReferenceNameFor(blueprintSpellbook);
            From = guid;

            DisplayName = blueprintSpellbook.DisplayName;
            CharacterClass = CharacterClasses.INSTANCE.GetReferenceNameFor(blueprintSpellbook.CharacterClass);

            IsArcane = blueprintSpellbook.IsArcane;
            IsSpontaneous = blueprintSpellbook.Spontaneous;
            CanCopyScrolls = blueprintSpellbook.CanCopyScrolls;
            AllSpellsKnown = blueprintSpellbook.AllSpellsKnown;
            CastingAttribute = blueprintSpellbook.CastingAttribute.ToString();
            SpellsPerLevel = blueprintSpellbook.SpellsPerLevel;
            CasterLevelModifier = blueprintSpellbook.CasterLevelModifier;
            Cantrips = blueprintSpellbook.CantripsType.ToString();

            SpellList = new SpellList(blueprintSpellbook.SpellList);
            if (blueprintSpellbook.SpellsKnown != null)
                SpellsKnown = new SpellsTable(blueprintSpellbook.SpellsKnown);
            if (blueprintSpellbook.SpellsPerDay != null)
                SpellsPerDay = new SpellsTable(blueprintSpellbook.SpellsPerDay);
            if (blueprintSpellbook.SpellSlots != null)
                SpellSlots = new SpellsTable(blueprintSpellbook.SpellSlots);
        }

        public Spellbook(JObject jObject) : base(jObject)
        {
            From = SelectString(jObject, "From");

            DisplayName = SelectString(jObject, "DisplayName");
            CharacterClass = SelectString(jObject, "CharacterClass");

            IsArcane = SelectBool(jObject, "IsArcane");
            IsSpontaneous = SelectBool(jObject, "IsSpontaneous");
            CanCopyScrolls = SelectBool(jObject, "CanCopyScrolls");
            AllSpellsKnown = SelectBool(jObject, "AllSpellsKnown");
            CastingAttribute = SelectString(jObject, "CastingAttribute");
            SpellsPerLevel = SelectInt(jObject, "SpellsPerLevel");
            CasterLevelModifier = SelectInt(jObject, "CasterLevelModifier");
            Cantrips = SelectString(jObject, "Cantrips");
            
            SpellsKnownFrom = SelectString(jObject, "SpellsKnownFrom");
            SpellsPerDayFrom = SelectString(jObject, "SpellsPerDayFrom");
            SpellSlotsFrom = SelectString(jObject, "SpellsSlotsFrom");
            SpellListFrom = SelectString(jObject, "SpellListFrom");

            JToken jSpellsKnown = jObject.SelectToken("SpellsKnown");
            if (jSpellsKnown != null)
                SpellsKnown = new SpellsTable(jSpellsKnown.Value<JObject>());
            JToken jSpellsPerDay = jObject.SelectToken("SpellsPerDay");
            if (jSpellsPerDay != null)
                SpellsPerDay = new SpellsTable(jSpellsPerDay.Value<JObject>());
            JToken jSpellSlots = jObject.SelectToken("SpellSlots");
            if (jSpellSlots != null)
                SpellList = new SpellList(jSpellSlots.Value<JObject>());
            JToken jSpellList = jObject.SelectToken("SpellList");
            if (jSpellList != null)
                SpellList = new SpellList(jSpellList.Value<JObject>());
        }

        [JsonProperty("From")]
        public string From { get; }
        [JsonProperty("DisplayName")]
        public string DisplayName { get; }
        [JsonProperty("CharacterClass")]
        public string CharacterClass { get; }
        [JsonProperty("IsArcane")]
        public bool? IsArcane { get; }
        [JsonProperty("IsSpontaneous")]
        public bool? IsSpontaneous { get; }
        [JsonProperty("CanCopyScrolls")]
        public bool? CanCopyScrolls { get; }
        [JsonProperty("AllSpellsKnown")]
        public bool? AllSpellsKnown { get; }
        [JsonProperty("CastingAttribute")]
        public string CastingAttribute { get; }
        [JsonProperty("SpellsPerLevel")]
        public int? SpellsPerLevel { get; }
        [JsonProperty("CasterLevelModifier")]
        public int? CasterLevelModifier { get; }
        [JsonProperty("Cantrips")]
        public string Cantrips { get; }
        [JsonProperty("SpellListFrom")]
        public string SpellListFrom { get; private set; }
        [JsonProperty("SpellsKnownFrom")]
        public string SpellsKnownFrom { get; private set; }
        [JsonProperty("SpellsPerDayFrom")]
        public string SpellsPerDayFrom { get; private set; }
        [JsonProperty("SpellSlotsFrom")]
        public string SpellSlotsFrom { get; private set; }
        [JsonProperty("SpellList")]
        public SpellList SpellList { get; private set; }
        [JsonProperty("SpellsKnown")]
        public SpellsTable SpellsKnown { get; private set; }
        [JsonProperty("SpellsPerDay")]
        public SpellsTable SpellsPerDay { get; private set; }
        [JsonProperty("SpellSlots")]
        public SpellsTable SpellSlots { get; private set; }
    }
}
