
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MultipleChoiceQuestions : MonoBehaviour
{

    [SerializeField] private Button[] multipleChoiceButton;
    private string buttonText;

    private void Start()
    {
        foreach (Button button in multipleChoiceButton)
        {
            button.onClick.AddListener(() => ChooseNumbers(button));
        }
    }

    public void ChooseNumbers(Button buttonClicked)
    {
        buttonText = buttonClicked.GetComponentInChildren<TextMeshProUGUI>().text;

        for (int i = 0; i < multipleChoiceButton.Length; i++)
        {
            int buttonTextNumber = int.Parse(buttonText);

            if (buttonTextNumber % 2 == 1)
            {
                buttonClicked.interactable = false;
            }
            else
            {
                buttonClicked.interactable = true;
            }
        }

    }
}
