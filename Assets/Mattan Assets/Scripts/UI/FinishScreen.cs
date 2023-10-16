using TMPro;
using UnityEngine;

public class FinishScreen : MonoBehaviour {
    [SerializeField] private GroundingLevelUIManager uIManager;
    [SerializeField] private TMP_Text [] taskTexts;
    [SerializeField] private TMP_Text [] chosenTexts;
    
    
    private void Awake() {
        ShowScreen();
    }

    void ShowScreen(){
        var pickedOptions = uIManager.pickedOptions;
        var uiManager = FindObjectOfType<GroundingLevelUIManager>();

        for (int i = 0; i < uiManager.stageScriptableObjects.Length ; i++)
        {
            var stageSO = uiManager.stageScriptableObjects[i];
            
            taskTexts[i].text = stageSO.taskInformation;
            chosenTexts[i].text = pickedOptions[i];
        }
    }
}