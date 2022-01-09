using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Repositories
{
    public class SpellbookRepository
    {
        public static BlueprintSpellbook Create(string name, string guid)
        {
            return Library.Create<BlueprintSpellbook>(name, guid);
        }

        public static BlueprintSpellsTable CreateSpellsTable(string name, string guid)
        {
            return Library.Create<BlueprintSpellsTable>(name, guid);
        }

        public static BlueprintSpellList CreateSpellList(string name, string guid)
        {
            return Library.Create<BlueprintSpellList>(name, guid);
        }

        public static BlueprintSpellbook Get(string guid)
        {
            return Library.Get<BlueprintSpellbook>(guid);
        }

        public static BlueprintAbility GetSpell(string guid)
        {
            return Library.Get<BlueprintAbility>(guid);
        }
    }
}
