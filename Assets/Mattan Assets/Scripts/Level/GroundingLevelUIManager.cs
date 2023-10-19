using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivation{
    public ButtonActivation (bool interactable, bool active) {this.interactable = interactable; this.active = active;}
    public bool interactable;
    public bool active;
}

public class GroundingLevelUIManager : MonoBehaviour {
#region serialized variables
    
    [Space, Header("Stages references")]
    [SerializeField] public GroundingStageScriptableObject [] stageScriptableObjects;
    
    [Space, Header("Ingame references")]
    [Header("Pot")]
    [SerializeField] private FillingPot potReference;
    [Header("Screen")]
    [SerializeField] private GameObject inGameScreen;
    [Header("Texts")]
    [SerializeField] private TMP_Text stageNumberText;
    [SerializeField] private TMP_Text taskInformation;

    [Header("Options buttons pool")]
    [SerializeField] private Button [] optionButtons;

    [Space, Header("Hug screen reference")]
    [SerializeField] private GameObject endHugGameScreen;
#endregion

#region static variables
    public static Action<string> clickedButton;
    public static Action<ButtonActivation> buttonsControl;
    public static Action startStage;
#endregion

#region non-serialized variables (and private variables)
    [HideInInspector] public List<string> pickedOptions;
    int currentStage = 0;
    int numberOfPicks = 0;
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
    void OnClickedButton(string option) {
        // if someone needs to cache that option
        pickedOptions.Add(option);
        // append number of picks 
        numberOfPicks++;
    }

    /// <summary>
    /// Sets all UI elements according to stage settings (changed by the scriptable objects provided)
    /// </summary>
    void StartStage(){
        numberOfPicks = 0;

        stageNumberText.text = "שלב " + (currentStage + 1).ToString();

        GroundingStageScriptableObject currentStageScriptable = stageScriptableObjects[currentStage];
        
        taskInformation.text = currentStageScriptable.taskInformation;

        potReference.maxCapacity = (float)currentStageScriptable.numberOfChoicesToPass;
        // set back to starting filling amount (basically removing sand from the pot)
        potReference.ResetPot();

        ButtonActivation activation = new ButtonActivation(true, true);
        buttonsControl?.Invoke(activation);
        
        for (int i = 0; i < optionButtons.Length; i++)
        {
            Button button = optionButtons[i];
            TMP_Text buttonText = button.transform.GetChild(0).GetComponent<TMP_Text>();

            if (i < currentStageScriptable.buttonsOptions.Length){
                buttonText.text = currentStageScriptable.buttonsOptions[i];
                button.gameObject.SetActive(true);
            }
            else{
                // hiding other buttons from the pool
                button.gameObject.SetActive(false);
            }
        }

        startStage?.Invoke();
    }


    /// <summary>
    /// called when a button has finished the animation of moving to the pot
    /// </summary>
    public void CheckFinishedStage(){
        // cache current stage scriptable
        GroundingStageScriptableObject currentStageScriptable = stageScriptableObjects[currentStage];
        // check if enough options were picked
        bool choseEnoughOptions = numberOfPicks >= currentStageScriptable.numberOfChoicesToPass;
        if (choseEnoughOptions){
            currentStage++;

            if (currentStage < stageScriptableObjects.Length){
                StartStage();
            }
            else{
                FinishGame();
            }
        }
        else{
            ButtonActivation activation = new ButtonActivation(interactable: true, active: false);
            buttonsControl?.Invoke(activation);
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