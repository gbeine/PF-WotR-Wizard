using System;
using Kingmaker.Blueprints;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Transformations.Components;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class ComponentFromJson
    {
        public static BlueprintComponent CreateBlueprintComponent(Component componentData)
        {
            Mod.Log($"Creating component from JSON data {componentData.Type}");

            BlueprintComponent component;
            if (ComponentDelegates.CanCreate(componentData))
                component = ComponentDelegates.CreateComponent(componentData);
            else
                throw new InvalidOperationException($"Cannot create component {componentData.Type}");
            
            return component;
        }
    }
}
