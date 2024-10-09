using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundingWordsLevel : MonoBehaviour
{
    [SerializeField] private GroundingLevelSO GroundingLevelSO;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button[] buttonsList;

    private void Start()
    {
        foreach (Button button in buttonsList) 
        {
            button.onClick.AddListener(Continue);
        }
    }
    private void Continue()
    {
        continueButton.gameObject.SetActive(true);
    }
}
