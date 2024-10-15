using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MovementLevel : MonoBehaviour
{
    private MovementLevelsContainer movementLevelsContainer;
    [SerializeField] private MovementLevelSO movementLevelSO;
    [SerializeField] private Button continueButton;

    private void Start()
    {
        movementLevelsContainer = GetComponentInParent<MovementLevelsContainer>();

        if (movementLevelsContainer != null)
        {
            continueButton.onClick.AddListener(movementLevelsContainer.RegisterLevelEnd);
        }
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

        float startTime = 0f;
        float endtime = movementLevelSO.time;

        while (startTime < endtime)
        {
            switch (movementLevelSO.movementType)
            {
                case MovementType.InfinityMovement:
                    break;

                case MovementType.UpAndDownMovement:
                    break;

                case MovementType.CircleMovement:
                    break;
            }

            yield return null;
        }

    }

}
