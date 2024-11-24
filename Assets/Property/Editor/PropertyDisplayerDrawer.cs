using System;
using System.Reflection;

using UnityEditor;
using UnityEngine;

using zer0.Property.Runtime;

namespace zer0.Property.Editor
{
    [CustomPropertyDrawer(typeof(PropertyDisplayerAttribute))]
    public class PropertyDisplayerDrawer : PropertyDrawer
    {
        private bool _drawn = false;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            PropertyDisplayerAttribute attri = (PropertyDisplayerAttribute)attribute;
            SerializedProperty field = property.serializedObject.FindProperty(attri.FieldName);
            object value = attri.Value;
            if (value is int && field.intValue == (int)attri.Value ||
                value is bool && field.boolValue == (bool)attri.Value ||
                value is string && field.stringValue == (string)attri.Value ||
                value is Enum && field.enumValueIndex == (int)attri.Value)
            {
                EditorGUI.PropertyField(position, property, label);
                _drawn = true;
            }
            else
            {
                _drawn = false;
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return _drawn ? EditorGUI.GetPropertyHeight(property, label) : 0.0f;
        }
    }
}
