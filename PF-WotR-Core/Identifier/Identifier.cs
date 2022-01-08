using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kingmaker.Blueprints;

namespace PF_WotR_Core.Identifier
{
    public abstract class Identifier
    {
        internal const string REFERENCE = "ref:";
        protected List<FieldInfo> _constants;
        protected IReadOnlyDictionary<string, string> _identifier;
        protected IReadOnlyDictionary<string, string> _reverseIdentifier;

        public Identifier()
        {
            Type type = this.GetType();

            _constants = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(
                    fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
                .ToList();

            _identifier = _constants.ToDictionary(fi => fi.Name, fi => (string)fi.GetRawConstantValue());
            _reverseIdentifier = _constants.ToDictionary(fi => (string)fi.GetRawConstantValue(), fi => fi.Name);
        }

        public bool Contains(string identifier)
        {
            return _identifier.ContainsKey(identifier) || _reverseIdentifier.ContainsKey(identifier);
        }

        public bool Contains(BlueprintGuid blueprintGuid)
        {
            return _reverseIdentifier.ContainsKey(blueprintGuid.ToString());
        }

        public string GetGuidFor(string name)
        {
            return _identifier[name];
        }

        public string GetNameFor(string guid)
        {
            return _reverseIdentifier[guid];
        }

        public string GetNameFor(BlueprintGuid blueprintGuid)
        {
            return _reverseIdentifier[blueprintGuid.ToString()];
        }

        public string GetReferenceNameFor(SimpleBlueprint blueprint)
        {
            return GetReferenceNameFor(blueprint.AssetGuid);
        }

        public string GetReferenceNameFor(BlueprintGuid blueprintGuid)
        {
            if (Contains(blueprintGuid))
            {
                return REFERENCE + _reverseIdentifier[blueprintGuid.ToString()];
            }

            return blueprintGuid.ToString();
        }

        public IReadOnlyDictionary<string, string> AllIdentifiers
        {
            get { return _identifier; }
        }
    }
}
