using System.Collections.Generic;
using UnityEngine;

public class LevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject> progressLevelobjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> levelObjects = new List<LevelObject>();
    public void ActivateLevels()
    {
        foreach (LevelObject levelObj in progressLevelobjects)
        {
            levelObj.gameObject.SetActive(true);
        }
    }

    public void RegisterLevelEnd()
    {
        for (int i = 0; i <= progressLevelobjects.Count; i++)
        {
            if (!progressLevelobjects.Contains(levelObjects[i]))
            {
                LevelButtonsEvents.OnLevelDone.Invoke(i, progressLevelobjects);
                break;
            }
        }

        DataSavingManager.Instance.SaveGame();
    }
    public void SaveData(ref GameData gameData)
    {
        gameData.levelObjects = progressLevelobjects;
    }

    public void LoadData(GameData gameData)
    {
        //gameData.levelObjects.Clear();

        progressLevelobjects = gameData.levelObjects;
    }

    public void RegisterPrecenet()
    {
        if (levelObjects != null && levelObjects.Count > 0)
        {
            LevelCollectivePrecent = 100 / levelObjects.Count;
        }
    }

}
