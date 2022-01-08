using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Extensions
{
    public static class PrerequisiteFeaturesFromListExtensions
    {
        public static void SetFeatures(this PrerequisiteFeaturesFromList c, List<BlueprintFeature> features)
        {
            set_Features(c, features
                .Select(feature => feature.ToReference<BlueprintFeatureReference>()).ToArray());
        }
        
        private static readonly Harmony.FastSetter<PrerequisiteFeaturesFromList, BlueprintFeatureReference[]> set_Features =
            Harmony.CreateFieldSetter<PrerequisiteFeaturesFromList, BlueprintFeatureReference[]>("m_Features");
    }
}
