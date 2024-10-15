using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovementLevel : MonoBehaviour
{
    private MovementLevelsContainer movementLevelsContainer;
    [SerializeField] private MovementLevelSO movementLevelSO;
    [SerializeField] private Button continueButton;
    [SerializeField] private Image movingCircle;

    private void Start()
    {
        movementLevelsContainer = GetComponentInParent<MovementLevelsContainer>();

        if (movementLevelsContainer != null)
        {
            continueButton.onClick.AddListener(movementLevelsContainer.RegisterLevelEnd);
        }

        StartCoroutine(MoveObject());
    }

    private void OnDisable()
    {
        if (movementLevelsContainer != null)
        {
            continueButton.onClick.RemoveListener(movementLevelsContainer.RegisterLevelEnd);
        }
    }

    private IEnumerator MoveObject()
    {
        Vector3 originalPos = movingCircle.transform.position;

        bool shouldObjectMove = true;

        while (shouldObjectMove)
        {
            switch (movementLevelSO.movementType)
            {
                case MovementType.InfinityMovement:
                    yield return InfinityMovement(originalPos);
                    break;

                case MovementType.LinearUpAndDownMovement:
                    yield return LinearUpAndDownMovement(originalPos);
                    break;

                case MovementType.EasedUpAndDownMovement:
                    yield return EasedUpAndDownMovement(originalPos);
                    break;
            }

            yield return null;
        }
    }

    private IEnumerator InfinityMovement(Vector3 originalPos)
    {
        float time = 0f;
        float width = 300.0f;
        float height = 300.0f * 0.6f;

        bool InfiniteMovementActive = true;

        while (InfiniteMovementActive)
        {
            time += Time.deltaTime * movementLevelSO.speed;

            float x = width * Mathf.Sin(time);
            float y = (height * (Mathf.Sin(2 * time)) / 2);

            movingCircle.transform.position = originalPos + new Vector3(x, y, 0f);

            yield return null;
        }
    }

    private IEnumerator LinearUpAndDownMovement(Vector3 originalPos)
    {
        float startTime = 0f;
        float endtime = movementLevelSO.time;

        Vector3 DownPosition = originalPos - new Vector3(0f, 100, 0f);
        Vector3 upPosition = originalPos;

        while (startTime < endtime)
        {
            startTime += Time.deltaTime;

            float progress = (startTime / endtime);

            movingCircle.transform.position = Vector3.Lerp(originalPos, DownPosition, progress);

            yield return null;
        }

        startTime = 0f;

        while (startTime < endtime)
        {
            startTime += Time.deltaTime;

            float progress = (startTime / endtime);

            movingCircle.transform.position = Vector3.Lerp(DownPosition, upPosition, progress);

            yield return null;
        }
    }
    private IEnumerator EasedUpAndDownMovement(Vector3 originalPos)
    {
        float startTime = 0f;
        float endtime = movementLevelSO.time;

        Vector3 DownPosition = originalPos - new Vector3(0f, 100, 0f);
        Vector3 upPosition = originalPos;

        while (startTime < endtime)
        {
            startTime += Time.deltaTime;

            float progress = (startTime / endtime);

            float easedProgress = Mathf.SmoothStep(0f, 1f, progress);

            movingCircle.transform.position = Vector3.Lerp(originalPos, DownPosition, easedProgress);

            yield return null;
        }

        startTime = 0f;

        while (startTime < endtime)
        {
            startTime += Time.deltaTime;

            float progress = (startTime / endtime);

            float easedProgress = Mathf.SmoothStep(0f, 1f, progress);

            movingCircle.transform.position = Vector3.Lerp(DownPosition, upPosition, easedProgress);

            yield return null;
        }
    }
}
