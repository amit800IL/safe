using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GroundingWordsLevel : MonoBehaviour
{
    [SerializeField] private GroundingLevelSO GroundingLevelSO;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button[] buttonsList;
    [SerializeField] private Transform wordTargetLocation;
    [SerializeField] private SandPotFilling sandPotFilling;

    public void WordMovingAndSandFill(Button button)
    {
        StartCoroutine(FillPot(button));
    }

    private IEnumerator FillPot(Button button)
    {
        foreach (Button groundingButton in buttonsList)
        {
            if (groundingButton != button)
            {
                groundingButton.interactable = false;
            }
        }

        float maxTime = 2.5f;
        float currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;

            float progress = currentTime / maxTime;

            button.transform.position = Vector3.Lerp(button.transform.position, wordTargetLocation.position, progress);

            yield return null;
        }


        yield return sandPotFilling.FillPot();

        continueButton.gameObject.SetActive(true);

    }

}
