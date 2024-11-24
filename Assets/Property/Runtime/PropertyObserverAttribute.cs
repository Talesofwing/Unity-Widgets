using UnityEngine;

namespace zer0.Property.Runtime
{
    public class PropertyObserverAttribute : PropertyAttribute
    {
        public string ChangedMethodName;        // The method that will be called when the property changed

        public PropertyObserverAttribute(string changedMethodName)
        {
            ChangedMethodName = changedMethodName;
        }
    }
}
