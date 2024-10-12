using System.Collections.Generic;
using UnityEngine;

public class LogicLevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject> logicLevelObjects = new List<LevelObject>();

    [SerializeField] List<LevelCompletionLinker> logicLevelCompletionLinker = new List<LevelCompletionLinker>();
    private void Awake()
    {
        DataSavingManager.Instance.RegisterSavable(this);
    }

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
        LevelObject.OnLevelDone?.Invoke(logicLevelCompletionLinker);

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        if (gameData == null) return;

        gameData.logicLevelCompletionLinker = new List<LevelCompletionLinker>(logicLevelCompletionLinker);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        logicLevelCompletionLinker = new List<LevelCompletionLinker>(gameData.logicLevelCompletionLinker);

        for (int i = 0; i < logicLevelCompletionLinker.Count; i++)
        {
            if (logicLevelCompletionLinker[i] != null)
            {
                logicLevelObjects[i].LevelCompletionLinker = logicLevelCompletionLinker[i];
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
