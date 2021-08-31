using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace NullFrameworkException.Editor
{
    [CustomPropertyDrawer(typeof(SceneFieldAttribute))]
    public class SceneFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
        {
            // start drawing this instance of the tag property
            EditorGUI.BeginProperty(_position, _label, _property);
            {
                // load the scene currently set in the inspector
                SceneAsset oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(SceneFieldAttribute.ToAssetPath(_property.stringValue));

                EditorGUI.BeginChangeCheck();
                
                // draw the scene field as an object field with the SceneAsset type
                SceneAsset newScene = EditorGUI.ObjectField(_position, _label, oldScene, typeof(SceneAsset), false) as SceneAsset;
                
                if (EditorGUI.EndChangeCheck())
                {
                    // set string path to path of new scene
                    string path = SceneFieldAttribute.LoadableName(AssetDatabase.GetAssetPath(newScene));
                    _property.stringValue = path;
                }
            }
            // stop drawing this instance of the tag property
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label) => EditorGUIUtility.singleLineHeight;
    } 
}
