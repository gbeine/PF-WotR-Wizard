using System.Collections.Generic;
using Kingmaker.Blueprints;
using Newtonsoft.Json.Linq;
using PF_WotR_Core.Identifier;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.JsonTypes.Components
{
    public class PrerequisiteFeaturesFromList: JsonComponent
    {
        public override Dictionary<string, JToken> ToJson(BlueprintComponent blueprintComponent)
        {
            Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteFeaturesFromList component =
                (Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteFeaturesFromList) blueprintComponent;
            
            Dictionary<string, JToken> values = new Dictionary<string, JToken>();
            values["CheckInProgression"] = new JValue(component.CheckInProgression);
            values["HideInUI"] = new JValue(component.HideInUI);
            values["Group"] = new JValue(component.Group.ToString());

            JArray features = new JArray();
            foreach (var feature in component.Features)
            {
                string referenceName = Features.INSTANCE.GetReferenceNameFor(feature);
                features.Add(new JValue(referenceName));
            }

            values["Features"] = features;
                
            return values;
        }
    }
}
