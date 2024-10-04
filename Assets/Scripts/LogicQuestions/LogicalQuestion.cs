using UnityEngine;
using UnityEngine.UI;

public class LogicalQuestion : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button[] questionButtons;
    [SerializeField] private int correctIndex;

    private void Start()
    {
        foreach (Button button in questionButtons)
        {
            button.onClick.AddListener(() => OptionsChoosing(button));
        }
    }

    public void OptionsChoosing(Button buttonClicked)
    {
        if (questionButtons[correctIndex] == buttonClicked)
        {
            buttonClicked.interactable = false;

            continueButton.gameObject.SetActive(true);
        }
        else
        {
            buttonClicked.interactable = true;
        }
    }
}
