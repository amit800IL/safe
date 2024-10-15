using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        supportLevelsContainer = GetComponentInParent<SupportLevelsContainer>();

        levelText.text = supporteExerciseSO.ExerciseText;

        finishText.text = supporteExerciseSO.FinishText;

        finishText.gameObject.SetActive(false);

        writeButton.onClick.AddListener(WriteText);
        continueButton.onClick.AddListener(supportLevelsContainer.RegisterLevelEnd);
        backButton.onClick.AddListener(LevelFinish);
    }

    private void OnDisable()
    {
        writeButton.onClick.RemoveListener(WriteText);
        continueButton.onClick.RemoveListener(supportLevelsContainer.RegisterLevelEnd);
        backButton.onClick.RemoveListener(LevelFinish);
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
