using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    /// <summary>
    /// this index is the opened level, above it are the locked levels, under it are the done levels. always above 0 value
    /// </summary>
    private int _unlockedLevels = 1;
    public int UnlockedLevels { get { return _unlockedLevels; } private set { _unlockedLevels = value; } }

    public int CurrentPressedLevelBTN;

    public bool HasLevelOpened(int levelIndex)//levelIndex is bigger then 0 always
    {
        CurrentPressedLevelBTN = levelIndex;
        if (levelIndex < _unlockedLevels)
            return true;
        return false;

    }


    //when player finish last opened level
    public void UnlockNextLevel()
    {
        if(UnlockedLevels - 1 != CurrentPressedLevelBTN)//cannot open if its a repit on done level
            return;
        if (_unlockedLevels < levelButtons.Length)
        {
            levelButtons[_unlockedLevels].interactable = true;
            _unlockedLevels++;
        }
    }

   
}
