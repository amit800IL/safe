using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelObjectSO))]
public class LevelObjectSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelObjectSO levelObject = (LevelObjectSO)target;

        GUI.enabled = false;

        SerializedProperty isLevelDoneProperty = serializedObject.FindProperty("IsLevelDone");

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
