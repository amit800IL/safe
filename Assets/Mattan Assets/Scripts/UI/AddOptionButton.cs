using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddOptionButton : MonoBehaviour
{
    [SerializeField] private Transform groundingLevelButtonContainer;
    [SerializeField] private GameObject groundLevelButtonPrefab;
    [SerializeField] private TMP_InputField inputField;

    string message = "";

    /// <summary>
    /// called by input field to save the message
    /// </summary>
    /// <param name="edittedMessage"></param>
    public void OnFinishedEdit(string edittedMessage) => message = edittedMessage;
    
    /// <summary>
    /// the on click event for the add button
    /// </summary>
    public void OnClick()
    {
        // avoid miss clicks
        if (message == "") return;

        // create a new level button
        GameObject newButton = Instantiate(groundLevelButtonPrefab, groundingLevelButtonContainer);
        GroundingLevelButton groundingLevelButton = newButton.GetComponent<GroundingLevelButton>();
        // set button message
        groundingLevelButton.myOptionText.text = message;
        // perform on click
        groundingLevelButton.myButton.onClick.Invoke();

        // reset the input field
        inputField.text = "";
        // reset the message
        message = "";
    }
}
