using UnityEngine;

namespace zer0.Property.Runtime
{
    public class PropertyDisplayerAttribute : PropertyAttribute
    {
        public string FieldName;
        public object Value;

        public PropertyDisplayerAttribute(string fieldName, object value)
        {
            FieldName = fieldName;
            Value = value;
        }
    }
}
