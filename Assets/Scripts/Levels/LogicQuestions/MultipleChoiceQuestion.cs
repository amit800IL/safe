using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelObject))]
public class MultipleChoiceQuestion : MonoBehaviour
{
    private LogicLevelObjectsContainer logicLevelObjectsContainer;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private MultipleChoiceQuestionSO multipleChoiceQuestionSO;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button[] multipleChoiceButton;

    private string buttonText;
    private List<Button> OddNumberButtons = new List<Button>();


    private void Start()
    {
        questionText.text = multipleChoiceQuestionSO.questionText;

        for (int i = 0; i < multipleChoiceButton.Length; i++)
        {
            TextMeshProUGUI buttonText = multipleChoiceButton[i].GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                buttonText.text = multipleChoiceQuestionSO.choicesText[i];
            }
        }

        foreach (Button button in multipleChoiceButton)
        {
            button.onClick.AddListener(() => ChooseNumbers(button));

            if (IsButtonNumberOdd(button))
            {
                OddNumberButtons.Add(button);
            }
        }

        logicLevelObjectsContainer = GetComponentInParent<LogicLevelObjectsContainer>();

        if (logicLevelObjectsContainer != null)
        {
            continueButton.onClick.AddListener(logicLevelObjectsContainer.RegisterLevelEnd);
        }

    }

    private void OnDisable()
    {
        if (logicLevelObjectsContainer != null)
        {
            continueButton.onClick.RemoveListener(logicLevelObjectsContainer.RegisterLevelEnd);
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
            bool IsNumberValid = int.TryParse(buttonText, out int number);

            return IsNumberValid ? number % 2 == 1 : false;
        }

        return false;
    }

}
