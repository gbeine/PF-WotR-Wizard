using Kingmaker.Blueprints.Facts;
using Kingmaker.Localization;
using PF_WotR_Core.Facades;
using PF_WotR_Core.Factories;
using UnityEngine;

namespace PF_WotR_Core.Extensions
{
    public static class BlueprintUnitFactExtensions
    {
        private static readonly LocalizationFactory _localizationFactory = new LocalizationFactory();
        
        public static void SetDisplayName(this BlueprintUnitFact blueprintUnitFact, string displayName)
        {
            LocalizedString localizedDisplayName = _localizationFactory.CreateString(blueprintUnitFact.name + ".Name", displayName);
            blueprintUnitFact_set_DisplayName(blueprintUnitFact, localizedDisplayName);
        }

        internal static void SetDescription(this BlueprintUnitFact blueprintUnitFact, string description)
        {
            LocalizedString localizedDescription = _localizationFactory.CreateString(blueprintUnitFact.name + ".Description", description);
            blueprintUnitFact_set_Description(blueprintUnitFact, localizedDescription);
        }

        internal static void SetDescriptionShort(this BlueprintUnitFact blueprintUnitFact, string descriptionShort)
        {
            LocalizedString localizedDescriptionShort = _localizationFactory.CreateString(blueprintUnitFact.name + ".DescriptionShort", descriptionShort);
            blueprintUnitFact_set_DescriptionShort(blueprintUnitFact, localizedDescriptionShort);
        }

        internal static void SetIcon(this BlueprintUnitFact blueprintUnitFact, Sprite icon)
        {
            blueprintUnitFact_set_Icon(blueprintUnitFact, icon);
        }

        private static readonly Harmony.FastSetter<BlueprintUnitFact, LocalizedString> blueprintUnitFact_set_DisplayName =
            Harmony.CreateFieldSetter<BlueprintUnitFact, LocalizedString>("m_DisplayName");

        private static readonly Harmony.FastSetter<BlueprintUnitFact, LocalizedString> blueprintUnitFact_set_Description =
            Harmony.CreateFieldSetter<BlueprintUnitFact, LocalizedString>("m_Description");

        private static readonly Harmony.FastSetter<BlueprintUnitFact, LocalizedString> blueprintUnitFact_set_DescriptionShort =
            Harmony.CreateFieldSetter<BlueprintUnitFact, LocalizedString>("m_DescriptionShort");

        private static readonly Harmony.FastSetter<BlueprintUnitFact, Sprite> blueprintUnitFact_set_Icon =
            Harmony.CreateFieldSetter<BlueprintUnitFact, Sprite>("m_Icon");
    }
}
