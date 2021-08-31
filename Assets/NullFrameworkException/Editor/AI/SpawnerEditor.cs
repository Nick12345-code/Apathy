using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace NullFrameworkException.Editor.AI
{
    [CustomEditor(typeof(Spawner))]
    public class SpawnerEditor : UnityEditor.Editor
    {
        // the reference to the component we are drawing the editor for
        private Spawner spawner;

        // the reference to the values of the variables held in the script
        private SerializedProperty sizeProperty;
        private SerializedProperty centerProperty;
        private SerializedProperty floorYPositionProperty;
        private SerializedProperty spawnRateProperty;
        private SerializedProperty shouldSpawnBossProperty;
        private SerializedProperty bossSpawnChanceProperty;
        private SerializedProperty bossPrefabProperty;
        private SerializedProperty enemyPrefabProperty;

        // the custom animation and elements
        private AnimBool shouldSpawnBoss = new AnimBool(); // allows animation of showing the boss variables when toggle is on
        private BoxBoundsHandle handle; // allows us to edit bounds of the box

        // OnEnable is the start of custom inspectors
        private void OnEnable()
        {
            // convert targetted object to Spawner type
            spawner = target as Spawner;

            // retrieve the serialized properties from the object
            sizeProperty = serializedObject.FindProperty("size");
            centerProperty = serializedObject.FindProperty("center");
            floorYPositionProperty = serializedObject.FindProperty("floorYPosition");
            spawnRateProperty = serializedObject.FindProperty("spawnRate");
            shouldSpawnBossProperty = serializedObject.FindProperty("shouldSpawnBoss");
            bossSpawnChanceProperty = serializedObject.FindProperty("bossSpawnChance");
            bossPrefabProperty = serializedObject.FindProperty("bossPrefab");
            enemyPrefabProperty = serializedObject.FindProperty("enemyPrefab");

            // set the animation bool for the boss spawning and create the handle
            shouldSpawnBoss.value = shouldSpawnBossProperty.boolValue;
            shouldSpawnBoss.valueChanged.AddListener(Repaint);
            handle = new BoxBoundsHandle();

        }

        // allows us to draw and modify things in scene view
        private void OnSceneGUI()
        {
            // set the handles colour to green and store the original matrix value
            Handles.color = Color.green;
            Matrix4x4 original = Handles.matrix;

            // change the handles matrix to using the transform of this object
            Handles.matrix = spawner.transform.localToWorldMatrix;

            // setup the box bounds handle with the spawner values
            handle.center = spawner.center;
            handle.size = spawner.size;

            // begin listening for changes to the handle and draw it
            EditorGUI.BeginChangeCheck();
            handle.DrawHandle();

            // check if any changes were made
            if (EditorGUI.EndChangeCheck())
            {
                // register this change for undo-redo system
                Undo.RecordObject(spawner, "UPDATE_SPAWNER_BOUNDS");

                // reset the spawner values to the new handle values
                spawner.size = handle.size;
                spawner.center = handle.center;
            }

            // reset handle's matrix back to original
            Handles.matrix = original;
        }

        // this is where we draw the custom inspector window and render the script properties
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // create a vertical layout group with it visualised as a box
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.PropertyField(centerProperty); // draw the center and size properties like unity would
            EditorGUILayout.PropertyField(sizeProperty);         
            EditorGUILayout.EndVertical();
                      
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.PropertyField(floorYPositionProperty);
            // cache the original value of the spawn rate
            Vector2 spawnRate = spawnRateProperty.vector2Value;
            string label = $"Range ({spawnRate.x:0.0}s - {spawnRate.y:0.0}s)";
            EditorGUILayout.MinMaxSlider(label, ref spawnRate.x, ref spawnRate.y, 0, 3);
            spawnRateProperty.vector2Value = spawnRate;
            // apply spacing between lines
            EditorGUILayout.Space();
            // render the enemyPrefab and shouldSpawnBoss as normal
            EditorGUILayout.PropertyField(enemyPrefabProperty);
            EditorGUILayout.PropertyField(shouldSpawnBossProperty);
            // attempting to fade variables in and out
            shouldSpawnBoss.target = shouldSpawnBossProperty.boolValue;
            if (EditorGUILayout.BeginFadeGroup(shouldSpawnBoss.faded))
            {
                // only visible when shouldSpawnBoss in Spawner script is true
                // indent the editor
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(bossSpawnChanceProperty);
                EditorGUILayout.PropertyField(bossPrefabProperty);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFadeGroup();
            EditorGUILayout.EndVertical();

            // apply changes
            serializedObject.ApplyModifiedProperties();
        }
    } 
}
