using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints.Classes.Spells;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PF_WotR_Core.JsonTypes
{
    public class SpellsTable : JsonType
    {
        public SpellsTable(BlueprintSpellsTable spellsTable) : base(spellsTable)
        {
            Table = new Dictionary<int, List<int>>(21);
            for (int i = 0; i < 21; i++)
            {
                Table[i] = spellsTable.Levels[i].Count.ToList();
            }
        }
        
        public SpellsTable(JObject jObject) : base(jObject)
        {
            // first int in each line is for cantrips
            // levels here are character levels
            JObject jTable = jObject.SelectToken("Table", true).Value<JObject>();
            Table = new Dictionary<int, List<int>>(21);
            for (int i = 0; i < 21; i++)
            {
                JArray jLevelEntry = jTable.SelectToken(i.ToString(), true).Value<JArray>();
                Table[i] = jLevelEntry.Values<int>().ToList(); 
            }
        }

        [JsonProperty("Table")]
        public Dictionary<int, List<int>> Table { get; }
    }
}
