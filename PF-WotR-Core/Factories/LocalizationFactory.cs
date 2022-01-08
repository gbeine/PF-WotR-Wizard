using System;
using System.Collections.Generic;
using Kingmaker.Localization;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Core.Factories
{
    public class LocalizationFactory
    {
        public LocalizedString CreateString(string key, string value)
        {
            Dictionary<String, String> strings = LocalizationManager.CurrentPack.Strings;

            String oldValue;
            if (strings.TryGetValue(key, out oldValue) && value != oldValue)
            {
                Mod.Warn($"Info: duplicate localized string `{key}`, different text.");
            }
            strings[key] = value;

            LocalizedString localized = new LocalizedString();
            localized.Key = key;

            return localized;
        }
    }
}
