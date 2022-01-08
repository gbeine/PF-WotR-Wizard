using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Repositories
{
    public class FeaturesRepository
    {
        public static BlueprintFeature Get(string guid)
        {
            return Library.Get<BlueprintFeature>(guid);
        }
    }
}
