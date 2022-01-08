using System;
using Kingmaker.Blueprints;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PF_WotR_Core.JsonTypes
{
    public abstract class JsonType : JsonWrap
    {
        protected JsonType(SimpleBlueprint simpleBlueprint) : base(new JObject())
        {
            Guid = simpleBlueprint.AssetGuid.ToString();
            Name = simpleBlueprint.name;
        }
        
        protected JsonType(JObject jObject) : base(jObject)
        {
            Guid = jObject.SelectToken("Guid", true).Value<string>();
            Name = jObject.SelectToken("Name", true).Value<string>();
        }

        protected bool isValid()
        {
            return false;
        }

        public String ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
        
        // private void SelectComponents(JObject jObject)
        // {
        //     JToken jComponents = jObject.SelectToken("Components");
        //     Components = Array.Empty<Component>().ToList();
        //     if (jComponents != null)
        //     {
        //         Components = new List<Component>();
        //         foreach (var jComponent in jComponents.Value<JArray>())
        //         {
        //             Components.Add(new Component(jComponent.Value<JObject>()));
        //         }
        //     }
        // }
        //
        // private void SelectComponentsFrom(JObject jObject)
        // {
        //     JToken jComponents = jObject.SelectToken("ComponentsFrom");
        //     ComponentsFrom = Array.Empty<Component>().ToList();
        //     if (jComponents != null)
        //     {
        //         foreach (var jComponent in jComponents.Value<JArray>())
        //         {
        //             ComponentsFrom.Add(new Component(jComponent.Value<JObject>()));
        //         }
        //     }
        // }

        [JsonProperty("Guid")]
        public string Guid { get; }
        [JsonProperty("Name")]
        public string Name { get; }
        // public bool ResetComponents { get; }
        // public List<string> RemoveComponents { get; }
        // public List<Component> Components { get; private set; }
        // public List<Component> ComponentsFrom { get; private set; }
    }
}
