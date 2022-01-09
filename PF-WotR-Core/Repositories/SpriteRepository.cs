using System;
using PF_WotR_Core.Identifier;
using UnityEngine;

namespace PF_WotR_Core.Repositories
{
    public class SpriteRepository
    {
        private static readonly IdentifierLookup _identifierLookup = IdentifierLookup.INSTANCE;

        internal static Sprite Get(String identifier)
        {
            if (identifier == null)
            {
                return null;
            }

            if (_identifierLookup.existsCharacterClass(identifier))
            {
                return CharacterClassesRepository.Get(
                    _identifierLookup.lookupCharacterClass(identifier)
                    ).Icon;
            }

            if (_identifierLookup.existsFeature(identifier))
            {
                return FeaturesRepository.Get(
                    _identifierLookup.lookupFeature(identifier)
                    ).Icon;
            }

            if (_identifierLookup.existsSpell(identifier))
            {
                return SpellbookRepository.GetSpell(
                    _identifierLookup.lookupSpell(identifier)
                    ).Icon;
            }

            // if (_identifierLookup.existsProgression(identifier))
            // {
            //     return ProgressionRepository.Get(
            //         _identifierLookup.lookupProgression(identifier)
            //     ).Icon;
            // }

            return null;
        }
    }
}
