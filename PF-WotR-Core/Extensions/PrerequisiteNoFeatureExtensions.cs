using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Extensions
{
    public static class PrerequisiteNoFeatureExtensions
    {
        public static void SetFeature(this PrerequisiteNoFeature c, BlueprintFeature feature)
        {
            set_Feature(c, feature.ToReference<BlueprintFeatureReference>());
        }
        
        private static readonly Harmony.FastSetter<PrerequisiteNoFeature, BlueprintFeatureReference> set_Feature =
            Harmony.CreateFieldSetter<PrerequisiteNoFeature, BlueprintFeatureReference>("m_Feature");
    }
}
