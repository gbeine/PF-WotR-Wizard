using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints.Classes.Spells;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Identifier;

namespace PF_WotR_Core.JsonTypes
{
    public class SpellList : JsonType
    {
        public SpellList(BlueprintSpellList spellList) : base(spellList)
        {
            SpellsByLevel = new Dictionary<int, List<string>>(spellList.SpellsByLevel.Length);
            Level = spellList.SpellsByLevel.Length > 0
                ? spellList.SpellsByLevel.Length - 1
                : 0;
            for (int i = 0; i < spellList.SpellsByLevel.Length; i++)
            {
                SpellsByLevel[i] = spellList.SpellsByLevel[i].Spells
                    .Select(spell => Abilities.INSTANCE.GetReferenceNameFor(spell))
                    .ToList();
            }
        }
        
        public SpellList(JObject jObject) : base(jObject)
        {
            // level 0 is for cantrips
            // levels here are spell levels
            JObject jSpellsByLevel = jObject.SelectToken("SpellsByLevel", true).Value<JObject>();
            Level = jSpellsByLevel.Count > 0
                ? jSpellsByLevel.Count - 1
                : 0;
            SpellsByLevel = new Dictionary<int, List<string>>(jSpellsByLevel.Count);
            for (int i = 0; i < jSpellsByLevel.Count; i++)
            {
                JArray jSpells = jSpellsByLevel.SelectToken(i.ToString(), true).Value<JArray>();
                SpellsByLevel[i] = jSpells.Values<string>().ToList();
            }
        }

        public int Level { get; }
        
        [JsonProperty("SpellsByLevel")]
        public Dictionary<int, List<string>> SpellsByLevel { get; }
    }
}
