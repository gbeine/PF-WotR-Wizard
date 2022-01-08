using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.Utility;
using PF_WotR_Core.JsonTypes;

namespace PF_WotR_Core.Transformations.Components
{
    public class DeityDependencyClassFromJson : ComponentFromJsonDelegate
    {
        public BlueprintComponent CreateComponent(Component componentData)
        {
            DeityDependencyClass c = new DeityDependencyClass();

            if (componentData.Exists("IsDeityDependencyClass"))
                c.IsDeityDependencyClass = componentData.AsBool("IsDeityDependencyClass");
            
            return c;
        }
    }
}