using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AstroTurffx.AstroUtils.Editor
{
    
    /// <summary>Makes the property uneditable in the inspector.</summary>
    public class ReadOnlyAttribute : PropertyAttribute
    {
 
    }
 
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
            => EditorGUI.GetPropertyHeight(property, label, true);

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
#endif
}