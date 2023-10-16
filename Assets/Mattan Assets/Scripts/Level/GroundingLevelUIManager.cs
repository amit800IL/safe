using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GroundingLevelUIManager : MonoBehaviour {
#region serialized variables
    
    [Space, Header("Stages references")]
    [SerializeField] public GroundingStageScriptableObject [] stageScriptableObjects;
    
    [Space, Header("Ingame references")]
    [Header("Screen")]
    [SerializeField] private GameObject inGameScreen;
    [SerializeField] private TMP_Text stageNumberText;
    [SerializeField] private TMP_Text taskInformation;

    [Header("Options buttons pool")]
    [SerializeField] private Button [] optionButtons;

    [Space, Header("Hug screen reference")]
    [SerializeField] private GameObject endHugGameScreen;
#endregion

#region static variables
    public static Action<string> clickedButton;
    public static Action startStage;
#endregion

#region non-serialized variables (and private variables)
    [HideInInspector] public List<string> pickedOptions;
    int currentStage = 0;
#endregion

    private void Awake() {
        StartStage();
    }

    private void OnEnable() {
        clickedButton += OnClickedButton;
    }
    private void OnDisable() {
        clickedButton -= OnClickedButton;
    }
    /// <summary>
    /// saves the options picked so the finish screen could pool it
    /// </summary>
    /// <param name="option"></param>
    void OnClickedButton(string option) => pickedOptions.Add(option);

    /// <summary>
    /// Sets all UI elements according to stage settings (changed by the scriptable objects provided)
    /// </summary>
    void StartStage(){
        stageNumberText.text = "שלב " + (currentStage + 1).ToString();

        GroundingStageScriptableObject currentStageScriptable = stageScriptableObjects[currentStage];
        taskInformation.text = currentStageScriptable.taskInformation;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            Button button = optionButtons[i];
            TMP_Text buttonText = button.transform.GetChild(0).GetComponent<TMP_Text>();


            if (i < currentStageScriptable.buttonsOptions.Length){
                buttonText.text = currentStageScriptable.buttonsOptions[i];
                button.gameObject.SetActive(true);
            }
            else{
                button.gameObject.SetActive(false);
            }
        }

        startStage?.Invoke();
    }

    /// <summary>
    /// called when a button has finished the animation of moving to the pot
    /// </summary>
    public void FinishedStage(){
        currentStage++;

        if (currentStage < stageScriptableObjects.Length){
            StartStage();
        }
        else{
            FinishGame();
        }
    }
    
    /// <summary>
    /// called when there are no more stages. Shows the "hug someone" screen as a wrapper
    /// </summary>
    void FinishGame(){
        inGameScreen.SetActive(false);
        endHugGameScreen.SetActive(true);
    }
}