using System.Collections.Generic;
using Kingmaker.Blueprints;
using PF_WotR_Core.JsonTypes;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations.Components
{
    public class ComponentDelegates
    {
        private static readonly Dictionary<string, ComponentFromJsonDelegate> Delegates =
            new Dictionary<string, ComponentFromJsonDelegate>();

        public static bool CanCreate(Component componentData) => Delegates.ContainsKey(componentData.Type);

        public static BlueprintComponent CreateComponent(Component componentData) =>
            Delegates[componentData.Type].CreateComponent(componentData);

        static ComponentDelegates()
        {
            Mod.Debug($"Adding delegate: DeityDependencyClass");
            Delegates.Add("DeityDependencyClass", new DeityDependencyClassFromJson());
            Mod.Debug($"Adding delegate: PrerequisiteIsPet");
            Delegates.Add("PrerequisiteAlignment", new PrerequisiteAlignmentFromJson());
            Mod.Debug($"Adding delegate: PrerequisiteIsPet");
            Delegates.Add("PrerequisiteFeaturesFromList", new PrerequisiteFeaturesFromListFromJson());
            Mod.Debug($"Adding delegate: PrerequisiteIsPet");
            Delegates.Add("PrerequisiteIsPet", new PrerequisiteIsPetFromJson());
            Mod.Debug($"Adding delegate: PrerequisiteIsPet");
            Delegates.Add("PrerequisiteNoClassLevel", new PrerequisiteNoClassLevelFromJson());
            Mod.Debug($"Adding delegate: PrerequisiteIsPet");
            Delegates.Add("PrerequisiteNoFeature", new PrerequisiteNoFeatureFromJson());
        }
    }
}
