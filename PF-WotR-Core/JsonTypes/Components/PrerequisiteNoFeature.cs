using System.Collections.Generic;
using Kingmaker.Blueprints;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Identifier;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.JsonTypes.Components
{
    public class PrerequisiteNoFeature : JsonComponent
    {
        public override Dictionary<string, JToken> ToJson(BlueprintComponent blueprintComponent)
        {
            Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoFeature component =
                (Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoFeature) blueprintComponent;
            
            Dictionary<string, JToken> values = new Dictionary<string, JToken>();
            values["CheckInProgression"] = new JValue(component.CheckInProgression);
            values["HideInUI"] = new JValue(component.HideInUI);
            values["Group"] = new JValue(component.Group.ToString());
            values["Feature"] = new JValue(Features.INSTANCE.GetReferenceNameFor(component.Feature));
            
            return values;
        }
    }
}