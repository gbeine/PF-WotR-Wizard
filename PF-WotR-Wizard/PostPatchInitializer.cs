using System;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using PF_WotR_ModKit.Utility;

namespace PF_WotR_Wizard
{
    public static class PostPatchInitializer
    {
        public static void Initialize() {
            var methods = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsClass)
                .SelectMany(x => AccessTools.GetDeclaredMethods(x))
                .Where(x => x.GetCustomAttributes(typeof(PostPatchInitializeAttribute), false).FirstOrDefault() != null);

            foreach (var method in methods) {
                Mod.Debug($"Executing Post Patch: {method.Name}");
                method.Invoke(null, null); // invoke the method
            }
        }
    }

    class PostPatchInitializeAttribute : Attribute {
    }
}
