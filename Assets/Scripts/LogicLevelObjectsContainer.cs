using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogicLevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    private List<LevelObject> LogicProgressLevelobjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> logicLevelObjects = new List<LevelObject>();

    public void ActivateLevels()
    {
        DataSavingManager.Instance.LoadGame();

        foreach (LevelObject levelObj in LogicProgressLevelobjects)
        {
            if (levelObj != null)
            {
                levelObj.gameObject.SetActive(false);
            }
        }

        LogicProgressLevelobjects.Last().gameObject.SetActive(true);
    }

    public void RegisterLevelEnd()
    {

        for (int i = 0; i <= logicLevelObjects.Count; i++)
        {
            if (!LogicProgressLevelobjects.Contains(logicLevelObjects[i]))
            {
                LevelButtonsEvents.OnLevelDone.Invoke(i, LogicProgressLevelobjects);
                break;
            }
        }

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
       gameData.logicLevelObjects = new List<LevelObject>(LogicProgressLevelobjects);
    }

    public void LoadData(GameData gameData)
    {
        LogicProgressLevelobjects = new List<LevelObject>(gameData.logicLevelObjects);
    }

    //public void RegisterPrecenet()
    //{
    //    if (levelObjects != null && levelObjects.Count > 0)
    //    {
    //        LevelCollectivePrecent = 100 / levelObjects.Count;
    //    }
    //}

}
