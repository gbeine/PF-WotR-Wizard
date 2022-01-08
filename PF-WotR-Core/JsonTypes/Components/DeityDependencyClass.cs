using System.Collections.Generic;
using Kingmaker.Blueprints;
using Newtonsoft.Json.Linq;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.JsonTypes.Components
{
    public class DeityDependencyClass : JsonComponent
    {
        public override Dictionary<string, JToken> ToJson(BlueprintComponent blueprintComponent)
        {
            Kingmaker.Blueprints.Classes.DeityDependencyClass component =
                (Kingmaker.Blueprints.Classes.DeityDependencyClass) blueprintComponent;
            
            Dictionary<string, JToken> values = new Dictionary<string, JToken>();
            values["IsDeityDependencyClass"] = new JValue(component.IsDeityDependencyClass);

            return values;
        }
    }
}
