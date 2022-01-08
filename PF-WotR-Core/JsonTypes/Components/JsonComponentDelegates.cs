using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;

namespace PF_WotR_Core.JsonTypes.Components
{
    public class JsonComponentDelegates
    {
        private static readonly Dictionary<Type, JsonComponent> componentDeserializer = new Dictionary<Type, JsonComponent>();

        public static bool CanDelegate(BlueprintComponent blueprintComponent)
        {
            return componentDeserializer.ContainsKey(blueprintComponent.GetType());
        }

        public static JsonComponent GetDelegate(BlueprintComponent blueprintComponent)
        {
            return componentDeserializer[blueprintComponent.GetType()];
        }

        static JsonComponentDelegates()
        {
            componentDeserializer[typeof(Kingmaker.Blueprints.Classes.DeityDependencyClass)] = new DeityDependencyClass();
            componentDeserializer[typeof(Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteAlignment)] = new PrerequisiteAlignment();
            componentDeserializer[typeof(Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteFeaturesFromList)] = new PrerequisiteFeaturesFromList();
            componentDeserializer[typeof(Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteIsPet)] = new PrerequisiteIsPet();
            componentDeserializer[typeof(Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoClassLevel)] = new PrerequisiteNoClassLevel();
            componentDeserializer[typeof(Kingmaker.Blueprints.Classes.Prerequisites.PrerequisiteNoFeature)] = new PrerequisiteNoFeature();
        }
    }
}
