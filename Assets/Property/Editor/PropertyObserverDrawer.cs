using System;
using System.Reflection;

using UnityEditor;
using UnityEngine;

using zer0.Property.Runtime;

namespace zer0.Property.Editor
{
    [CustomPropertyDrawer(typeof(PropertyObserverAttribute))]
    public class PropertyObserverDrawer : PropertyDrawer
    {
        private bool _isDirty = false;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            EditorGUI.PropertyField(position, property, label);
            PropertyObserverAttribute attr = attribute as PropertyObserverAttribute;

            if (EditorGUI.EndChangeCheck())
            {
                _isDirty = true;
            }
            else if (_isDirty)
            {
                object parent = property.serializedObject.targetObject;
                Type type = parent.GetType();
                MethodInfo method = type.GetMethod(attr.ChangedMethodName, BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (method == null)
                {
                    Debug.LogError("Invalied method name: " + attr.ChangedMethodName);
                }
                else
                {
                    method.Invoke(parent, null);
                }
                _isDirty = false;
            }
        }
    }
}
