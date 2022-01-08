using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.JsonTypes.Components;

namespace PF_WotR_Core.JsonTypes
{
    public class JsonDynamicType : JsonWrap
    {
        protected Dictionary<string, JToken> values = new Dictionary<string, JToken>();

        protected JsonDynamicType(BlueprintComponent blueprintComponent) : base(new JObject())
        {
            if (JsonComponentDelegates.CanDelegate(blueprintComponent))
            {
                values = JsonComponentDelegates.GetDelegate(blueprintComponent).ToJson(blueprintComponent);
            }
        }

        protected JsonDynamicType(JObject jObject) : base(jObject)
        {
            foreach (var entry in jObject.SelectToken("Values").Value<JObject>())
            {
                values[entry.Key] = entry.Value;
            }
        }

        [JsonProperty("Values")]
        public Dictionary<string, JToken> Values => values;

        public bool Exists(string key)
        {
            return values.ContainsKey(key);
        }

        public T As<T>(string key) where T : JsonWrap
        {
            return (T) Activator.CreateInstance(
                typeof(T), values[key]);
        }

        public List<T> AsList<T>(string key) where T : JsonWrap
        {
            List<T> list = new List<T>();
            foreach (var jObject in values[key].Values<JObject>())
            {
                list.Add((T) Activator.CreateInstance(
                    typeof(T), jObject));
            }

            return list;
        }

        public IEnumerable<string> AsArray(string key)
        {
            return values[key].Values<string>();
        }

        public bool AsBool(string key)
        {
            return values[key].Value<bool>();
        }

        public int AsInt(string key)
        {
            return values[key].Value<int>();
        }

        public string AsString(string key)
        {
            return values[key].Value<string>();
        }
    }
}
