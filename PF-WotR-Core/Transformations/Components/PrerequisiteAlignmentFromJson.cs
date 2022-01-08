using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic.Alignments;
using Kingmaker.Utility;
using PF_WotR_Core.JsonTypes;

namespace PF_WotR_Core.Transformations.Components
{
    public class PrerequisiteAlignmentFromJson : ComponentFromJsonDelegate
    {
        public BlueprintComponent CreateComponent(Component componentData)
        {
            PrerequisiteAlignment c = new PrerequisiteAlignment();

            if (componentData.Exists("CheckInProgression"))
                c.CheckInProgression = componentData.AsBool("CheckInProgression");
            if (componentData.Exists("HideInUI"))
                c.HideInUI = componentData.AsBool("HideInUI");
            if (componentData.Exists("Group"))
                c.Group = EnumParser.parseGroupType(componentData.AsString("Group"));
            if (componentData.Exists("Alignment"))
            {
                AlignmentMaskType alignmentMask = AlignmentMaskType.None;
                componentData.AsArray("Alignment").ForEach(a => alignmentMask |= EnumParser.parseAlignment(a));
                c.Alignment = alignmentMask;
            }
            
            return c;
        }
    }
}