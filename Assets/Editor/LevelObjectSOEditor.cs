using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelObjectSO), true)]
public class LevelObjectSOEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

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

        DrawPropertiesExcluding(serializedObject, "IsLevelDone");

        serializedObject.ApplyModifiedProperties();
    }
}
