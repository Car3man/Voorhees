using System;

namespace Voorhees {
    /// Indicates that the field or property should be mapped to a specific key
    /// when mapping to and from JSON data.
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class JsonKeyAttribute : Attribute {
        public string Key { get; }

        public JsonKeyAttribute(string key) {
            Key = key;
        }
    }
}