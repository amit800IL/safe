using UnityEngine;
using UnityEngine.UI;

public class FillingPot : MonoBehaviour, ISavable
{

    [Header("References")]
    [SerializeField] private Image fillImage;
    [SerializeField] public Transform pouringSpot;

    [Space, Header("Animation Variables")]
    [SerializeField] private Animator sandDotsAnimator;
    [SerializeField] private string startPouringTrigger = "start";
    [SerializeField] private string finishedPouringTrigger = "finish";


    [Space, Header("Variables")]
    [SerializeField] private float maxCapacity = 1f;
    [SerializeField] private float startingFillingAmount = 0.15f;
    [SerializeField] private float fillingSpeed = 0.2f;
    [SerializeField] private float currentFillAmount = 0.15f;

    float nextFillingAmount = 0f;
    bool isPouring = false;

    private void Awake()
    {
        fillImage.fillAmount = currentFillAmount;
    }

    /// <summary>
    /// add a fraction of maxCapacity to the pot.
    /// tween using poured sand.
    /// called by some GroundingLevelButton
    /// </summary>
    public void DissolveIntoPot()
    {
        sandDotsAnimator.SetTrigger(startPouringTrigger);

        nextFillingAmount = fillImage.fillAmount + 1 / maxCapacity;

        nextFillingAmount = Mathf.Clamp(nextFillingAmount, 0f, 1f);
    }

    /// <summary>
    /// called by sand dots animator when finished starting the pour animation to start
    /// filling the sand image
    /// </summary>
    public void OnFinishedStartingToPour()
    {
        isPouring = true;
    }

    private void Update()
    {
        if (isPouring)
        {
            fillImage.fillAmount += fillingSpeed * Time.deltaTime;

            if (fillImage.fillAmount >= nextFillingAmount)
            {
                FinishedPouring();
            }
        }
    }

    /// <summary>
    /// stop pouring and make the sand image stop pouring as well
    /// </summary>
    public void FinishedPouring()
    {
        sandDotsAnimator.SetTrigger(finishedPouringTrigger);
        isPouring = false;

        currentFillAmount = fillImage.fillAmount;

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.pourImageFill = currentFillAmount;
    }

    public void LoadData(GameData gameData)
    {
        currentFillAmount = gameData.pourImageFill;
    }
}