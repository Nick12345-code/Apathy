using UnityEngine;
using UnityEditor;

namespace NullFrameworkException.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            // start drawing this instance of the tag property
            EditorGUI.BeginProperty(_position, _label, _property);
            {
                // disable GUI, making this readonly (non-interactable)
                GUI.enabled = false;
                {
                    EditorGUI.PropertyField(_position, _property, _label);
                }
                // enables GUI, making everything workable
                GUI.enabled = true;
            }
            // stop drawing this instance of the tag property
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label) => EditorGUI.GetPropertyHeight(_property);
    } 
}
