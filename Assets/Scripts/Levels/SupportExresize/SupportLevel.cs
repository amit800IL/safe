using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelObject))]
public class SupportLevel : MonoBehaviour
{
    private SupportLevelsContainer supportLevelsContainer;
    [SerializeField] private SupporteExerciseSO supporteExerciseSO;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private Button writeButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button backButton;
    private const int maxCharchters = 1000;


    private void Start()
    {
        levelText.text = supporteExerciseSO.ExerciseText;

        finishText.text = supporteExerciseSO.FinishText;

        finishText.gameObject.SetActive(false);

        writeButton.onClick.AddListener(WriteText);
        backButton.onClick.AddListener(LevelFinish);

        supportLevelsContainer = GetComponentInParent<SupportLevelsContainer>();

        if (supportLevelsContainer != null)
        {
            continueButton.onClick.AddListener(supportLevelsContainer.RegisterLevelEnd);
        }
    }

    private void OnDisable()
    {
        writeButton.onClick.RemoveListener(WriteText);
        backButton.onClick.RemoveListener(LevelFinish);

        if (supportLevelsContainer != null)
        {
            continueButton.onClick.RemoveListener(supportLevelsContainer.RegisterLevelEnd);
        }
    }

    public void WriteText()
    {
        TouchScreenKeyboard.Open(" ", TouchScreenKeyboardType.Default);
    }

    public void LevelFinish()
    {
        finishText.gameObject.SetActive(true);
    }
}
