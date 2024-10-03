using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
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

        currentFillAmount = fillImage.fillAmount;

        Debug.Log("Finished pouring. Current fill amount: " + currentFillAmount);

        DataSavingManager.Instance.SaveGame();

        isPouring = false;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.pourImageFill = this.currentFillAmount;
    }

    public void LoadData(GameData gameData)
    {
        this.currentFillAmount = gameData.pourImageFill;
    }
}