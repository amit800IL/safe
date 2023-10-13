using System.Linq;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class LogicalQuestions : MonoBehaviour
{
    [SerializeField] private Button[] questionButtons;

    private void Start()
    {
        foreach (Button button in questionButtons)
        {
            button.onClick.AddListener(() => OptionsChoosing(button));
        }
    }

    public void OptionsChoosing(Button buttonClicked)
    {
        for (int i = 0; i < questionButtons.Length; i++)
        {
            if (questionButtons.ElementAt(i) == questionButtons.ElementAt(0))
            {
                buttonClicked.interactable = false;
            }
        }
    }
}
