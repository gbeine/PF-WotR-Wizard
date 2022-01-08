using Kingmaker.Blueprints.Classes;
using PF_WotR_Core.Facades;

namespace PF_WotR_Core.Repositories
{
    public static class StatProgressionRepository
    {
        public static BlueprintStatProgression Get(string guid)
        {
            return Library.Get<BlueprintStatProgression>(guid);
        }
    }
}