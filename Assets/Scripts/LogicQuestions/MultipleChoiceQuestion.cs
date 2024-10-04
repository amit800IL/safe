
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MultipleChoiceQuestion : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    [SerializeField] private Button[] multipleChoiceButton;

    private string buttonText;
    List<Button> OddNumberButtons = new List<Button>();
    private void Start()
    {
        foreach (Button button in multipleChoiceButton)
        {
            button.onClick.AddListener(() => ChooseNumbers(button));

            if (IsButtonNumberOdd(button))
            {
                OddNumberButtons.Add(button);
            }
        }
    }

    public void ChooseNumbers(Button buttonClicked)
    {
        for (int i = 0; i < multipleChoiceButton.Length; i++)
        {
            if (IsButtonNumberOdd(buttonClicked))
            {
                buttonClicked.interactable = false;
            }
            else
            {
                buttonClicked.interactable = true;
            }

        }

        if (OddNumberButtons.All(button => !button.interactable))
        {
            continueButton.gameObject.SetActive(true);
        }
    }

    private bool IsButtonNumberOdd(Button button)
    {
        buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;

        if (buttonText != null)
        {
            int buttonTextNumber = int.Parse(buttonText);

            return buttonTextNumber % 2 == 1;
        }

        return false;
    }

}
