using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Kingmaker.Blueprints;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PF_WotR_Core.JsonTypes
{
    public class Component : JsonDynamicType
    {
        private const string pattern = @"(.*\.)";

        public Component(BlueprintComponent blueprintComponent) : base(blueprintComponent)
        {
            Type = Regex.Replace(blueprintComponent.GetType().ToString(), pattern, String.Empty);
        }

        public Component(JObject jObject) : base(jObject)
        {
            Type = jObject.SelectToken("Type", true).Value<string>();
        }

        [JsonProperty("Type")]
        public string Type { get; }
    }
}
