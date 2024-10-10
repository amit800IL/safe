using System.Collections.Generic;
using UnityEngine;

public class LogicLevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    private List<LevelObject> LogicProgressLevelobjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> logicLevelObjects = new List<LevelObject>();

    [SerializeField] List<LevelCompletionLinker> logicLevelCompletionLinker = new List<LevelCompletionLinker>();

    Dictionary<bool, LevelObject> levelCompletionLDictionary = new Dictionary<bool, LevelObject>();


    //public void ActivateLevels()
    //{
    //    DataSavingManager.Instance.LoadGame();

    //    foreach (LevelObject levelObj in LogicProgressLevelobjects)
    //    {
    //        if (levelObj != null)
    //        {
    //            levelObj.gameObject.SetActive(false);
    //        }
    //    }

    //    LogicProgressLevelobjects.Last().gameObject.SetActive(true);
    //}

    public void RegisterLevelEnd()
    {

        for (int i = 0; i <= logicLevelObjects.Count; i++)
        {
            if (!LogicProgressLevelobjects.Contains(logicLevelObjects[i]))
            {
                LevelObject.OnLevelDone.Invoke(LogicProgressLevelobjects, logicLevelCompletionLinker);
                break;
            }
        }

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.logicLevelObjects = new List<LevelObject>(LogicProgressLevelobjects);
        gameData.logicLevelCompletionLinker = new List<LevelCompletionLinker>(logicLevelCompletionLinker);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        LogicProgressLevelobjects = new List<LevelObject>(gameData.logicLevelObjects);
        logicLevelCompletionLinker = new List<LevelCompletionLinker>(gameData.logicLevelCompletionLinker);

        foreach (LevelCompletionLinker Linker in logicLevelCompletionLinker)
        {
            if (Linker.levelObject != null)
            {
                Linker.levelObject.SetCompletionStatus(Linker.IsLevelDone);
            }
        }
    }

    //public void RegisterPrecenet()
    //{
    //    if (levelObjects != null && levelObjects.Count > 0)
    //    {
    //        LevelCollectivePrecent = 100 / levelObjects.Count;
    //    }
    //}

}
