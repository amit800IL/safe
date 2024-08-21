using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is the "משהו אחר" button. The purpose of this class is to mimic the behaviour
/// of the GroundLevelButton class on other buttons.
/// </summary>
public class SomethingElseButtonManager : MonoBehaviour
{
    [SerializeField] private Button myButton;

    private void OnEnable()
    {
        GroundingLevelUIManager.clickedButton += OnClickedSomeButton;
        GroundingLevelUIManager.startStage += OnStartStage;
    }

    private void OnDisable()
    {
        GroundingLevelUIManager.clickedButton -= OnClickedSomeButton;
        GroundingLevelUIManager.startStage -= OnStartStage;
    }

    private void OnClickedSomeButton(string chosenOption)
    {
        myButton.interactable = false;
    }
    private void OnStartStage()
    {
        myButton.interactable = true;
        myButton.gameObject.SetActive(true);
    }
}
