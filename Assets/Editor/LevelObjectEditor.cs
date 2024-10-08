using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelObject))]
public class LevelObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelObject levelObject = (LevelObject)target;

        GUI.enabled = false;

        SerializedProperty isLevelDoneProperty = serializedObject.FindProperty("isLevelDone");

        if (isLevelDoneProperty != null)
        {
            EditorGUILayout.PropertyField(isLevelDoneProperty, new GUIContent("Is Level Done"));
        }
        else
        {
            EditorGUILayout.LabelField("isLevelDone property not found!");
        }

        GUI.enabled = true;

        serializedObject.ApplyModifiedProperties();
    }
}
