using System.Linq;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.JsonTypes;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class FeatureFromJson
    {
        internal static void SetValuesFromData(BlueprintFeature feature, Feature featureData)
        {
            Mod.Log("Setting feature data");

            // if (!string.Empty.Equals(featureData.Icon))
            //     feature.SetIcon(SpriteLookup.lookupFor(featureData.Icon));

            feature.SetDisplayName(featureData.DisplayName);
            feature.SetDescription(featureData.Description);

            if (featureData.FeatureGroups.Count > 0)
                feature.Groups = 
                    featureData.FeatureGroups
                        .Select(featureGroup => EnumParser.parseFeatureGroup(featureGroup)).ToArray();

            // ComponentFromJson.ProcessComponents(feature, featureData, characterClass);

            Mod.Log("DONE: Setting feature data");
        }
    }
}