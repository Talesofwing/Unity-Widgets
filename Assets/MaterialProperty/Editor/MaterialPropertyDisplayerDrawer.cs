using UnityEngine;
using UnityEditor;

public class MaterialPropertyDisplayerDrawer : MaterialPropertyDrawer
{
    private string _propertyName;

    public MaterialPropertyDisplayerDrawer() { }

    public MaterialPropertyDisplayerDrawer(string propertyName)
    {
        _propertyName = propertyName;
    }

    public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
    {
        Material mat = editor.target as Material;
        if (mat != null)
        {
            MaterialProperty property = MaterialEditor.GetMaterialProperty(new Object[] { mat }, _propertyName);
            if (property != null && property.floatValue == 1)
            {
                editor.DefaultShaderProperty(position, prop, label);
            }
        }
    }

    public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
    {
        Material mat = editor.target as Material;
        if (mat != null)
        {
            MaterialProperty property = MaterialEditor.GetMaterialProperty(new Object[] { mat }, _propertyName);
            if (property != null && property.floatValue == 1)
            {
                return MaterialEditor.GetDefaultPropertyHeight(prop);
            }
        }

        return 0;
    }
}
