using Kingmaker.Blueprints.Classes.Spells;
using PF_WotR_Core.Factories;
using PF_WotR_Core.JsonTypes;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Transformations
{
    public class SpellsTableFromJson : JsonTransformation
    {
        private static readonly SpellbookFactory _spellbookFactory = new SpellbookFactory();

        public static BlueprintSpellsTable GetSpellsTable(SpellsTable spellsTableData)
        {
            Mod.Log($"Creating spells table from JSON data {spellsTableData.Guid}");

            BlueprintSpellsTable spellsTable = _spellbookFactory.CreateSpellsTable(
                spellsTableData.Name, spellsTableData.Guid, spellsTableData.Table);

            Mod.Log("DONE: Creating spell list");
            return spellsTable;
        }
    }
}
