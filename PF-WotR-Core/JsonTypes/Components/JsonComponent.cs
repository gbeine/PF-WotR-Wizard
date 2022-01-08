using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Newtonsoft.Json.Linq;

namespace PF_WotR_Core.JsonTypes.Components
{
    public abstract class JsonComponent
    {
        public abstract Dictionary<string, JToken> ToJson(BlueprintComponent blueprintComponent);
    }
}