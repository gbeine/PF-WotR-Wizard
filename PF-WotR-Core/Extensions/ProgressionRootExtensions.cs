using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Extensions
{
    public static class ProgressionRootExtensions
    {
        internal static List<BlueprintCharacterClassReference> GetCharacterClassReferences(this ProgressionRoot progressionRoot)
        {
            return progressionRoot_CharacterClasses(progressionRoot).ToList();
        }

        internal static void SetCharacterClassReferences(this ProgressionRoot progressionRoot, List<BlueprintCharacterClassReference> references)
        {
            progressionRoot_set_CharacterClasses(progressionRoot, references.ToArray());
        }

        private static readonly Harmony.FastRef<ProgressionRoot, BlueprintCharacterClassReference[]> progressionRoot_CharacterClasses =
            Harmony.CreateFieldGetter<ProgressionRoot, BlueprintCharacterClassReference[]>("m_CharacterClasses");
        
        private static readonly Harmony.FastSetter<ProgressionRoot, BlueprintCharacterClassReference[]> progressionRoot_set_CharacterClasses =
            Harmony.CreateFieldSetter<ProgressionRoot, BlueprintCharacterClassReference[]>("m_CharacterClasses");
    }
}
