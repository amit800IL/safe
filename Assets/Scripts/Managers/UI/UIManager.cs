using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private GameObject[] _levelPanels;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    
    /// <summary>
    /// even called when the player pressed on a level button in the level map.
    /// </summary>
    /// <param name="pressedLevelIndex"></param>
    public void ActivateLevelPanel(int pressedLevelIndex)
    {
        //checks if the level is locked or not.
        if (!_levelManager.HasLevelOpened(pressedLevelIndex - 1))
            return;
        //activate the pressed opened or done level.
        _levelPanels[pressedLevelIndex - 1].SetActive(true);
    }

    public void BackToMenuPanel()
    {
        _levelPanels[_levelManager.CurrentPressedLevelBTN].SetActive(false);
        //_levelManager.UnlockNextLevel();
    }

    public void OpenNextLevel() // a method to open next level obviously lol
    {
        _levelPanels[_levelManager.CurrentPressedLevelBTN].SetActive(false); // close the current level panel
        _levelManager.UnlockNextLevel(); // unlock the next level
        int currentLevelActualIndex = _levelManager.CurrentPressedLevelBTN + 1; // get the actual current level index
        ActivateLevelPanel(currentLevelActualIndex + 1); // open the next level panel
    }


}
