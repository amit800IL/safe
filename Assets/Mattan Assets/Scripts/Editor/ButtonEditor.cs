using UnityEngine.UI;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Button))]
public class ButtonEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        ShowEditorButton();
    }

    /// <summary>
    /// will allow to click any button on edit mode
    /// </summary>
    void ShowEditorButton(){

        GUILayout.Label(""); // providing space from the base GUI

        if(GUILayout.Button("Activate On Click")){
            ((Button)target).onClick.Invoke();
        }
    }
}