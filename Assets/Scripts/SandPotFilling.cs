using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SandPotFilling : MonoBehaviour
{
    [SerializeField] private Image sandImage;
    [SerializeField] private float sandFillAmount;

    public IEnumerator FillPot()
    {
        float maxTime = 2.5f;
        float currentTime = 0f;

        currentTime = 0f;

        while (currentTime < maxTime)
        {
            currentTime += Time.deltaTime;

            float progress = currentTime / maxTime;

            sandImage.fillAmount = Mathf.Lerp(sandFillAmount, sandFillAmount + 0.1f, progress);

            yield return null;
        }

        sandFillAmount = sandImage.fillAmount;

        yield return null;
    }
}
