using System;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Harmony = PF_WotR_Core.Facades.Harmony;

namespace PF_WotR_Core.Extensions
{
    public static class BlueprintProgressionExtensions
    {
        internal static BlueprintProgression Clone(this BlueprintProgression clone, BlueprintProgression original)
        {
            return clone;
        }

        internal static void SetUIDeterminatorsGroup(this BlueprintProgression blueprintProgression, IEnumerable<BlueprintFeatureBase> features)
        {
            BlueprintFeatureBaseReference[] featureBaseReferences = features
                .Select(f => f.ToReference<BlueprintFeatureBaseReference>())
                .ToArray();

            blueprintProgression_set_UIDeterminatorsGroup(blueprintProgression, featureBaseReferences);
        }

        internal static void SetClass(this BlueprintProgression blueprintProgression, BlueprintCharacterClass characterClass)
        {
            BlueprintProgression.ClassWithLevel classWithLevel = new BlueprintProgression.ClassWithLevel() {
                m_Class = characterClass.ToReference<BlueprintCharacterClassReference>(),
                AdditionalLevel = 0
            };

            blueprintProgression.AddClass(classWithLevel);
        }
        internal static void AddClass(this BlueprintProgression blueprintProgression, BlueprintProgression.ClassWithLevel classWithLevel)
        {
            CollectionExtensions.AddRangeToArray(
                blueprintProgression_Classes(blueprintProgression),
                new BlueprintProgression.ClassWithLevel[1] { classWithLevel });
        }

        private static readonly Harmony.FastSetter<BlueprintProgression, BlueprintFeatureBaseReference[]> blueprintProgression_set_UIDeterminatorsGroup =
            Harmony.CreateFieldSetter<BlueprintProgression, BlueprintFeatureBaseReference[]>("m_UIDeterminatorsGroup");
        
        private static readonly Harmony.FastRef<BlueprintProgression, BlueprintProgression.ClassWithLevel[]> blueprintProgression_Classes =
            Harmony.CreateFieldGetter<BlueprintProgression, BlueprintProgression.ClassWithLevel[]>("m_Classes");
    }
}