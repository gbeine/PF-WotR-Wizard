using System;
using System.Collections.Generic;
using Kingmaker.Blueprints.Classes.Spells;
using PF_WotR_Core.Extensions;
using PF_WotR_Core.Repositories;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Factories
{
    public class SpellbookFactory
    {
        public BlueprintSpellbook CreateSpellbookFrom(String name, String guid, String fromAssetGuid)
        {
            Mod.Debug($"Create spellbook {name} with id {guid} based on {fromAssetGuid}");

            BlueprintSpellbook original = SpellbookRepository.Get(fromAssetGuid);
            BlueprintSpellbook clone = SpellbookRepository.Create(name, guid);
           
            clone.Clone(original);

            Mod.Debug($"DONE: Create spellbook {name} with id {guid} based on {fromAssetGuid}");
            return clone;

        }

        public BlueprintSpellbook CreateSpellbook(String name, String guid)
        {
            Mod.Debug($"Create spellbook {name} with id {guid}");

            BlueprintSpellbook spellbook = SpellbookRepository.Create(name, guid);

            Mod.Debug($"DONE: Create spellbook {name} with id {guid}");
            return spellbook;
        }
        
        public BlueprintSpellList CreateSpellList(String name, String guid, int level)
        {
            Mod.Debug($"Create spell list {name} with id {guid}");

            BlueprintSpellList spellList = SpellbookRepository.CreateSpellList(name, guid);

            // +1 here because 0 are cantrips, levels go from one to the value of level
            spellList.SpellsByLevel = new SpellLevelList[level+1];

            for (int i = 0; i < spellList.SpellsByLevel.Length; i++)
            {
                spellList.SpellsByLevel[i] = new SpellLevelList(i);
            }

            Mod.Debug($"DONE: Create spell list {name} with id {guid}");
            return spellList;
        }

        public BlueprintSpellsTable CreateSpellsTable(String name, String guid, List<SpellsLevelEntry> levels)
        {
            Mod.Debug($"Create spells table {name} with id {guid}");

            BlueprintSpellsTable spellsTable = SpellbookRepository.CreateSpellsTable(name, guid);
            spellsTable.Levels = levels.ToArray();

            Mod.Debug($"DONE: Create spells table {name} with id {guid}");
            return spellsTable;
        }
        public BlueprintSpellsTable CreateSpellsTable(String name, String guid, Dictionary<int, List<int>> levels)
        {
            Mod.Debug($"Create spells table {name} with id {guid}");

            List<SpellsLevelEntry> spellsLevelEntries = new List<SpellsLevelEntry>();
            foreach (var level in levels.Values)
            {
                SpellsLevelEntry levelEntry = CreateSpellsLevelEntry(level.ToArray());
                spellsLevelEntries.Add(levelEntry);
            }

            BlueprintSpellsTable spellsTable = CreateSpellsTable(name, guid, spellsLevelEntries);

            Mod.Debug($"DONE: Create spells table {name} with id {guid}");
            return spellsTable;
        }

        private SpellsLevelEntry CreateSpellsLevelEntry(params int[] count)
        {
            Mod.Debug($"Create spells level entry with {count.Length}");

            SpellsLevelEntry spellsLevelEntry = new SpellsLevelEntry();
            spellsLevelEntry.Count = count;

            Mod.Debug("DOME: Create spells level entry");
            return spellsLevelEntry;
        }

    }
}