using Kingmaker.Blueprints;
using PF_WotR_Core.JsonTypes;

namespace PF_WotR_Core.Transformations.Components
{
    public interface ComponentFromJsonDelegate
    {
        BlueprintComponent CreateComponent(Component componentData);
    }
}