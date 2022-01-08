using System;
using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.JsonTypes;
using PF_WotR_Core.Repositories;
using PF_WotR_Core.Transformations;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Loader
{
    public class CharacterClassLoader : Loader
    {
        private CharacterClass _characterClass;
        private BlueprintCharacterClass _blueprintCharacterClass;

        public CharacterClassLoader(String filename) : base(filename) { }

        public override bool load()
        {
            Mod.Debug($"Parsing character class from {_filename}");
            
            _characterClass = new CharacterClass(_jObject);
            _blueprintCharacterClass = CharacterClassFromJson.CreateBlueprintCharacterClass(_characterClass);
            CharacterClassesRepository.Add(_blueprintCharacterClass);
            
            Mod.Log($"DONE: Parsing character class {_characterClass.Guid}");
            return true;
        }
        //
        // public BlueprintCharacterClass CharacterClass
        // {
        //     get { return CharacterClassFromJson.GetCharacterClass(_characterClass); }
        // }
    }
}
