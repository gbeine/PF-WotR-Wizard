using Kingmaker.Blueprints.Classes.Spells;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Repositories
{
    public class SpellbookRepository
    {
        public static BlueprintSpellbook Create(string name, string guid)
        {
            return Library.Create<BlueprintSpellbook>(name, guid);
        }

        public static BlueprintSpellbook Get(string guid)
        {
            return Library.Get<BlueprintSpellbook>(guid);
        }
    }
}
