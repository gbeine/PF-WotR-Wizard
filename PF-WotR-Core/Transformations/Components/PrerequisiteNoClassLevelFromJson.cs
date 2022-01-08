using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Identifier;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;

namespace PF_WotR_Core.Transformations.Components
{
    public class PrerequisiteNoClassLevelFromJson : ComponentFromJsonDelegate
    {
        public BlueprintComponent CreateComponent(Component componentData)
        {
            PrerequisiteNoClassLevel c = new PrerequisiteNoClassLevel();

            if (componentData.Exists("CheckInProgression"))
                c.CheckInProgression = componentData.AsBool("CheckInProgression");
            if (componentData.Exists("HideInUI"))
                c.HideInUI = componentData.AsBool("HideInUI");
            if (componentData.Exists("Group"))
                c.Group = EnumParser.parseGroupType(componentData.AsString("Group"));
            if (componentData.Exists("CharacterClass"))
                c.SetCharacterClass(getCharacterClass(componentData.AsString("CharacterClass")));

            return c;
        }
        
        private static BlueprintCharacterClass getCharacterClass(string value) =>
            CharacterClassesRepository.Get(IdentifierLookup.INSTANCE.lookupCharacterClass(value));
    }
}