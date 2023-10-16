using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is the "משהו אחר" button. The purpose of this class is to mimic the behaviour
/// of the GroundLevelButton class on other buttons.
/// </summary>
public class SomethingElseButtonManager : MonoBehaviour
{
    [SerializeField] private Button myButton;

    void OnEnable(){
        GroundingLevelUIManager.clickedButton   += OnClickedSomeButton;
        GroundingLevelUIManager.startStage      += OnStartStage;
    }
    void OnDisable(){
        GroundingLevelUIManager.clickedButton   -= OnClickedSomeButton;
        GroundingLevelUIManager.startStage      -= OnStartStage;
    }

    void OnClickedSomeButton(string chosenOption){
        myButton.interactable = false;
    }
    void OnStartStage(){
        myButton.interactable = true;
        myButton.gameObject.SetActive(true);
    }
}
