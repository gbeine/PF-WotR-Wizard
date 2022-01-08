using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Extensions
{
    public static class PrerequisiteNoClassLevelExtensions
    {
        public static void SetCharacterClass(this PrerequisiteNoClassLevel c, BlueprintCharacterClass characterClass)
        {
            set_CharacterClass(c, characterClass.ToReference<BlueprintCharacterClassReference>());
        }
        
        private static readonly Harmony.FastSetter<PrerequisiteNoClassLevel, BlueprintCharacterClassReference> set_CharacterClass =
            Harmony.CreateFieldSetter<PrerequisiteNoClassLevel, BlueprintCharacterClassReference>("m_CharacterClass");
    }
}
