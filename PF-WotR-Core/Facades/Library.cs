using System;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Root;

namespace PF_WotR_Core.Facades
{
    public static class Library
    {
        public static ProgressionRoot GetProgression()
        {
            return ResourcesLibrary.GetRoot().Progression;
        }

        public static T Get<T>(string guid) where T : BlueprintScriptableObject
        {
            return ResourcesLibrary.TryGetBlueprint<T>(new BlueprintGuid(Guid.Parse(guid)));
        }

        public static T Create<T>(string name, string guid) where T : SimpleBlueprint, new()
        {
            BlueprintGuid assetId = new BlueprintGuid(new Guid(guid));
            T asset = new T()
            {
                name = name,
                AssetGuid = assetId
            };
            ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(assetId, asset);
            return asset;
        }
    }
}
