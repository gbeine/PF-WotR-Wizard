using System;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Identifier
{
    public class IdentifierLookup
    {
        internal static readonly IdentifierLookup INSTANCE = new IdentifierLookup();

        private IdentifierLookup() { }

        // internal string lookupAbility(string value) => performLookup(Abilities.INSTANCE, value);
        // internal string lookupAbilityAreaEffect(string value) => performLookup(AbilityAreaEffects.INSTANCE, value);
        // internal string lookupBuff(string value) => performLookup(Buffs.INSTANCE, value);
        internal string lookupArchetype(string value) => performLookup(Archetypes.INSTANCE, value);
        internal string lookupCharacterClass(string value) => performLookup(CharacterClasses.INSTANCE, value);
        internal string lookupFeature(string value) => performLookup(Features.INSTANCE, value);
        // internal string lookupFeatureSelection(string value) => performLookup(FeatureSelections.INSTANCE, value);
        // internal string lookupItem(string value) => performLookup(Items.INSTANCE, value);
        internal string lookupProgression(string value) => performLookup(Features.INSTANCE, value);
        internal string lookupSpell(string value) => performLookup(Abilities.INSTANCE, value);
        internal string lookupSpellbook(string value) => performLookup(Spellbooks.INSTANCE, value);
        // internal string lookupSpellList(string value) => performLookup(SpellLists.INSTANCE, value);
        internal string lookupStatProgression(string value) => performLookup(StatProgession.INSTANCE, value);

        internal bool existsCharacterClass(string value) => performExists(CharacterClasses.INSTANCE, value, typeof(BlueprintCharacterClass));
        internal bool existsFeature(string value) => performExists(Features.INSTANCE, value, typeof(BlueprintFeature));
        // internal bool existsProgression(string value) => performExists(Progressions.INSTANCE, value, typeof(BlueprintProgression));
        internal bool existsSpell(string value) => performExists(Abilities.INSTANCE, value,typeof(BlueprintAbility));
        internal bool existsSpellbook(string value) => performExists(Spellbooks.INSTANCE, value, typeof(BlueprintSpellbook));

        private string performLookup(Identifier identifierInstance, string value)
        {
            Mod.Debug($"Lookup identifier for {value}");
            if (value != null)
            {
                if (value.StartsWith(Identifier.REFERENCE))
                {
                    return identifierInstance.GetGuidFor(value.Replace(Identifier.REFERENCE, ""));
                }
            }
            // if the identifier not starts with a certain string we simply return it
            // that's maybe not the best idea and but it ok for now...
            return value;
        }

        private bool performExists(Identifier identifierInstance, string value, Type type)
        {
            Mod.Debug($"Test if identifier for {value} exists");
            bool exists = false;
            if (value != null)
            {
                if (value.StartsWith(Identifier.REFERENCE))
                {
                    exists |= identifierInstance.Contains(value.Replace(Identifier.REFERENCE, ""));
                }
            }
            return exists;
        }
    }
}
