using System;
using UnityEngine;
using UnityEngine.UI;

public class FillingPot : MonoBehaviour {

    [Header("References")]
    [SerializeField] private Image fillImage;
    [SerializeField] public Transform pouringSpot; 

    [Space, Header("Animation Variables")]
    [SerializeField] private Animator sandDotsAnimator;
    [SerializeField] private string startPouringTrigger = "start";
    [SerializeField] private string finishedPouringTrigger = "finish";


    [Space, Header("Variables")]
    [SerializeField] public float maxCapacity              = 1f;
    [SerializeField] private float startingFillingAmount    = 0.15f;
    [SerializeField] private float fillingSpeed             = 0.2f;

    
    public Action finishedDroppingSand;

    float nextFillingAmount = 0f;
    bool isPouring = false;


    private void Awake() {
        ResetPot();
    }

    public void ResetPot() => fillImage.fillAmount = startingFillingAmount;

    /// <summary>
    /// add a fraction of maxCapacity to the pot.
    /// tween using poured sand.
    /// called by some GroundingLevelButton
    /// </summary>
    public void DissolveIntoPot(){
        sandDotsAnimator.SetTrigger(startPouringTrigger);

        nextFillingAmount = fillImage.fillAmount + 1 / maxCapacity;

        nextFillingAmount = Mathf.Clamp(nextFillingAmount, 0f, 1f);
    }

    /// <summary>
    /// called by sand dots animator when finished starting the pour animation to start
    /// filling the sand image
    /// </summary>
    public void OnFinishedStartingToPour(){
        isPouring = true;
    }

    private void Update() {
        if (isPouring){

            fillImage.fillAmount += fillingSpeed * Time.deltaTime;

            if (fillImage.fillAmount >= nextFillingAmount){
                FinishedPouring();
            }
        }
    }

    /// <summary>
    /// stop pouring and make the sand image stop pouring as well
    /// </summary>
    public void FinishedPouring(){
        sandDotsAnimator.SetTrigger(finishedPouringTrigger);
        isPouring = false;
        
    }

    /// <summary>
    /// finished the sand dropletts
    /// </summary>
    public void OnFinishedDroppingSand(){
        var groundingStageUI = FindObjectOfType<GroundingLevelUIManager>();
        groundingStageUI.CheckFinishedStage();
        finishedDroppingSand?.Invoke();
    }
}