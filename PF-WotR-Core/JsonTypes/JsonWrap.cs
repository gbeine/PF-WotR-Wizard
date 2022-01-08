using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace PF_WotR_Core.JsonTypes
{
    public abstract class JsonWrap
    {
        protected readonly JObject _jObject;

        protected JsonWrap(JObject jObject)
        {
            _jObject = jObject;
        }

        protected List<string> SelectStringList(JToken jObject, string key, string[] defaultValue)
        {
            JToken jToken = jObject.SelectToken(key);
            return jToken?.Values<string>().ToList() ?? defaultValue.ToList();
        }

        protected List<string> SelectStringList(JToken jObject, string key)
        {
            return SelectStringList(jObject, key, Array.Empty<string>());
        }

        protected string SelectString(JToken jObject, string key, string defaultValue)
        {
            JToken jToken = jObject.SelectToken(key);
            return jToken?.Value<string>() ?? defaultValue;
        }

        protected string SelectString(JToken jObject, string key)
        {
            return SelectString(jObject, key, string.Empty);
        }

        protected bool SelectBool(JToken jObject, string key, bool defaultValue)
        {
            JToken jToken = jObject.SelectToken(key);
            return jToken?.Value<bool>() ?? defaultValue;
        }

        protected bool? SelectBool(JToken jObject, string key)
        {
            JToken jToken = jObject.SelectToken(key);
            return jToken?.Value<bool>();
        }

        protected int SelectInt(JToken jObject, string key, int defaultValue)
        {
            JToken jToken = jObject.SelectToken(key);
            return jToken?.Value<int>() ?? defaultValue;
        }

        protected int? SelectInt(JToken jObject, string key)
        {
            JToken jToken = jObject.SelectToken(key);
            return jToken?.Value<int>();
        }
    }
}
