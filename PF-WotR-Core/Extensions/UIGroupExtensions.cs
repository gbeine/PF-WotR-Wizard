using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Extensions
{
    public static class UIGroupExtensions
    {
     
        internal static void SetFeatures(this UIGroup uiGroup, IEnumerable<BlueprintFeatureBase> features)
        {
            List<BlueprintFeatureBaseReference> featureBaseReferences =
                features.Select<BlueprintFeatureBase, BlueprintFeatureBaseReference>(
                    (Func<BlueprintFeatureBase, BlueprintFeatureBaseReference>) (
                        f => f.ToReference<BlueprintFeatureBaseReference>())).ToList<BlueprintFeatureBaseReference>();

            uiGroup_set_Features(uiGroup, featureBaseReferences);
        }
        
        private static readonly Harmony.FastRef<UIGroup, List<BlueprintFeatureBaseReference>> uiGroup_Features =
            Harmony.CreateFieldGetter<UIGroup, List<BlueprintFeatureBaseReference>>("m_Features");

        private static readonly Harmony.FastSetter<UIGroup, List<BlueprintFeatureBaseReference>> uiGroup_set_Features =
            Harmony.CreateFieldSetter<UIGroup, List<BlueprintFeatureBaseReference>>("m_Features");
    }
}