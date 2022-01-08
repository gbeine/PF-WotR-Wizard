using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Extensions;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Factories
{
    public class UIGroupFactory
    {
        public UIGroup CreateUIGroup(params BlueprintFeatureBase[] features)
        {
            Mod.Debug($"Create UI group");

            UIGroup uiGroup = new UIGroup();
            uiGroup.SetFeatures(features);

            return uiGroup;
        }
    }
}
