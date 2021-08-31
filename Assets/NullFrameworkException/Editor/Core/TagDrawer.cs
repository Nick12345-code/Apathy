using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NullFrameworkException.Editor
{
    [CustomPropertyDrawer(typeof(TagAttribute))] 
    public class TagDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            // start drawing this instance of the tag property
            EditorGUI.BeginProperty(_position, _label, _property);
            {
                // determine if property was set to nothing by default
                bool isNotSet = string.IsNullOrEmpty(_property.stringValue);

                // draw the string as a tag instead of a normal string box
                _property.stringValue = EditorGUI.TagField(_position, _label, isNotSet ? (_property.serializedObject.targetObject as Component)?.gameObject.tag : _property.stringValue);
            }
            // stop drawing this instance of the tag property
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label) => EditorGUIUtility.singleLineHeight;
    } 
}
