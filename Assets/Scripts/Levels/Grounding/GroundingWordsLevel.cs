using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelObject))]
public class GroundingWordsLevel : MonoBehaviour
{
    private GroundingLevelObjectsContainer groundingLevelObjectsContainer;
    [SerializeField] private GroundingLevelSO GroundingLevelSO;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button[] buttonsList;
    [SerializeField] private Transform wordTargetLocation;
    [SerializeField] private SandPotFilling sandPotFilling;

    private void Start()
    {
        for (int i = 0; i < buttonsList.Length; i++)
        {
            TextMeshProUGUI buttonText = buttonsList[i].GetComponentInChildren<TextMeshProUGUI>();

            buttonText.text = GroundingLevelSO.buttonxText[i];
        }

        groundingLevelObjectsContainer = GetComponentInParent<GroundingLevelObjectsContainer>();

        if (groundingLevelObjectsContainer != null)
        {
            continueButton.onClick.AddListener(groundingLevelObjectsContainer.RegisterLevelEnd);
        }

    }

    private void OnDisable()
    {
        if (groundingLevelObjectsContainer != null)
        {
            continueButton.onClick.RemoveListener(groundingLevelObjectsContainer.RegisterLevelEnd);
        }
    }

    public void WordMovingAndSandFill(Button button)
    {
        StartCoroutine(FillPot(button));
    }

    private IEnumerator FillPot(Button button)
    {
        foreach (Button buttonObject in buttonsList)
        {
            buttonObject.interactable = false;
        }

        yield return MoveWordToPositon(button);

        yield return sandPotFilling.FillPot();

        continueButton.gameObject.SetActive(true);

    }

    private IEnumerator MoveWordToPositon(Button button)
    {
        float maxTime = 2.5f;
        float currentTime = 0f;

        Vector3 buttonPosition = button.transform.position;
        Vector3 wordsTargetPosition = wordTargetLocation.position;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;

            float progress = currentTime / maxTime;

            button.transform.position = Vector3.Lerp(buttonPosition, wordsTargetPosition, progress);

            yield return null;
        }
    }

}
