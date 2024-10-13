using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelObject))]
public class LogicalQuestion : MonoBehaviour
{
    [SerializeField] private LogicLevelObjectsContainer logicLevelObjectsContainer;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private LogicQuestionsSO logicQuestionSO;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button[] questionButtons;

    private void Start()
    {
        questionText.text = logicQuestionSO.questionText;

        for (int i = 0; i < questionButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = questionButtons[i].GetComponentInChildren<TextMeshProUGUI>();

            buttonText.text = logicQuestionSO.buttonxText[i];
        }

        foreach (Button button in questionButtons)
        {
            button.onClick.AddListener(() => OptionsChoosing(button));
        }

        continueButton.onClick.AddListener(logicLevelObjectsContainer.RegisterLevelEnd);
    }

    private void OnDisable()
    {
        continueButton.onClick.RemoveListener(logicLevelObjectsContainer.RegisterLevelEnd);
    }

    public void OptionsChoosing(Button buttonClicked)
    {
        if (questionButtons[logicQuestionSO.CorrectIndex] == buttonClicked)
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
