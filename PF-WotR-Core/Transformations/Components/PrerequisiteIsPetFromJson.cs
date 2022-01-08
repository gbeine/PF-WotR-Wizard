using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using PF_WotR_Core.JsonTypes;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations.Components
{
    public class PrerequisiteIsPetFromJson : ComponentFromJsonDelegate
    {
        public BlueprintComponent CreateComponent(Component componentData)
        {
            PrerequisiteIsPet c = new PrerequisiteIsPet();

            if (componentData.Exists("CheckInProgression"))
                c.CheckInProgression = componentData.AsBool("CheckInProgression");
            if (componentData.Exists("HideInUI"))
                c.HideInUI = componentData.AsBool("HideInUI");
            if (componentData.Exists("Group"))
                c.Group = EnumParser.parseGroupType(componentData.AsString("Group"));
            if (componentData.Exists("Not"))
                c.Not = componentData.AsBool("Not");
            
            return c;
        }
    }
}