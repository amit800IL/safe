using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelObject))]
public class BreathingLevel : MonoBehaviour
{
    private BreathingLevelObjectsCotainer breathingLevelObjectsCotainer;
    [SerializeField] private BreathingLevelSO breathingLevelSO;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Image FilligImage;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        breathingLevelObjectsCotainer = GetComponentInParent<BreathingLevelObjectsCotainer>();

        if (breathingLevelObjectsCotainer != null)
        {
            continueButton.onClick.AddListener(breathingLevelObjectsCotainer.RegisterLevelEnd);
        }

        StartCoroutine(BreathingLevelCoroutine());
    }

    private void OnDisable()
    {
        if (breathingLevelObjectsCotainer != null)
        {
            continueButton.onClick.AddListener(breathingLevelObjectsCotainer.RegisterLevelEnd);
        }
    }

    public IEnumerator BreathingLevelCoroutine()
    {
        yield return BreathingIn();
        yield return HoldingBreath();
        yield return BreathingOut();

        continueButton.gameObject.SetActive(true);
    }


    public IEnumerator BreathingIn()
    {
        levelText.text = breathingLevelSO.BreathingInText;
        FilligImage.sprite = breathingLevelSO.BreathingInSprite;

        float StartTime = 0f;

        float MaxTime = breathingLevelSO.BreathingInTimer;

        float zeroFill = 0f;

        while (StartTime < MaxTime)
        {
            StartTime += Time.deltaTime;

            float Progress = StartTime / MaxTime;

            FilligImage.fillOrigin = 0;

            float full = 1f;

            FilligImage.fillAmount = Mathf.Lerp(zeroFill, full, Progress);

            yield return null;
        }

        FilligImage.fillAmount = zeroFill;
    }

    public IEnumerator HoldingBreath()
    {
        levelText.text = breathingLevelSO.HoldingBreathText;
        FilligImage.sprite = breathingLevelSO.HoldingBreathSprite;

        float StartTime = 0f;

        float MaxTime = breathingLevelSO.HoldingBreathTimer;

        FilligImage.fillAmount = 1f;

        while (StartTime < MaxTime)
        {
            StartTime += Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator BreathingOut()
    {
        levelText.text = breathingLevelSO.BreathingOutText;
        FilligImage.sprite = breathingLevelSO.BreathingOutSprite;

        float StartTime = 0f;

        float MaxTime = breathingLevelSO.BreathingOutTimer;

        float zeroFill = 0f;

        while (StartTime < MaxTime)
        {
            StartTime += Time.deltaTime;

            float Progress = StartTime / MaxTime;

            FilligImage.fillOrigin = 1;

            float full = 1f;

            FilligImage.fillAmount = Mathf.Lerp(zeroFill, full, Progress);

            yield return null;
        }

        FilligImage.fillAmount = zeroFill;
    }
}
