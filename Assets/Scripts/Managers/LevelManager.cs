using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    
    /// <summary>
    /// this index is the opened level, above it are the locked levels, under it are the done levels.
    /// </summary>
    public int UnlockedLevels { get; private set; } = 0;

    public int CurrentPressedLevelBTN;

    public Action OnUnlockedLevel;

    public List<ILevelDataProvider> Levels = new List<ILevelDataProvider>();
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Levels = FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None).OfType<ILevelDataProvider>().ToList();
        Levels.OrderBy(level => level.GetLevelData().LevelNumber);
    }
    
    public bool HasLevelOpened(int levelIndex)
    {
        CurrentPressedLevelBTN = levelIndex;
        foreach (var levelUI in Levels)
        {
            if (levelUI.GetLevelData().LevelNumber == levelIndex)
            {
                return true;
            }
        }
        return false;
    }
    
    //when player finish last opened level
    public void UnlockNextLevel()
    {
        if (UnlockedLevels != CurrentPressedLevelBTN)
            return;

        foreach (var levelUI in Levels)
        {
            var levelData = levelUI.GetLevelData();
            if (levelData.LevelNumber != UnlockedLevels) continue;
            if (levelData.IsComplete) continue;
            levelData.IsComplete = true;
            UnlockedLevels++;
            OnUnlockedLevel?.Invoke();
            break;
        }
    }

    public void ResetAllLevels()
    {
        foreach (var level in Levels)
        {
            level.GetLevelData().IsComplete = false;
        }
    }
}
