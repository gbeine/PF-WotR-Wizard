using System.Collections.Generic;
using Kingmaker.Blueprints;
using Newtonsoft.Json.Linq;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.JsonTypes.Components
{
    public class PrerequisiteAlignment: JsonComponent
    {
        public override Dictionary<string, JToken> ToJson(BlueprintComponent blueprintComponent)
        {
            Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteAlignment component =
                (Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteAlignment) blueprintComponent;
            
            Dictionary<string, JToken> values = new Dictionary<string, JToken>();
            values["CheckInProgression"] = new JValue(component.CheckInProgression);
            values["HideInUI"] = new JValue(component.HideInUI);
            values["Group"] = new JValue(component.Group.ToString());

            JArray alignment = new JArray();
            alignment.Add(new JValue(component.Alignment.ToString()));
            values["Alignment"] = alignment;

            return values;
        }
    }
}