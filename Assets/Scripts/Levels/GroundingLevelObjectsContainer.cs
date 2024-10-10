using System.Collections.Generic;
using UnityEngine;


public class GroundingLevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    private List<LevelObject> groundProgressLevelObjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> groundingLevelObjects = new List<LevelObject>();

    [SerializeField] List<LevelCompletionLinker> groundingLevelsCompletionLinker = new List<LevelCompletionLinker>();

    //public void ActivateLevels()
    //{
    //    DataSavingManager.Instance.LoadGame();

    //    foreach (LevelObject levelObj in groundProgressLevelObjects)
    //    {
    //        if (levelObj != null)
    //        {
    //            levelObj.gameObject.SetActive(false);
    //        }
    //    }

    //    groundProgressLevelObjects.Last().gameObject.SetActive(true);
    //}

    public void RegisterLevelEnd()
    {
        for (int i = 0; i < groundingLevelObjects.Count; i++)
        {
            if (!groundProgressLevelObjects.Contains(groundingLevelObjects[i]))
            {
                LevelObject.OnLevelDone?.Invoke(groundProgressLevelObjects, groundingLevelsCompletionLinker);
                break;
            }
        }

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.groundinLevelObjects = new List<LevelObject>(groundProgressLevelObjects);
        gameData.groundingLevelCompletionLinker = new List<LevelCompletionLinker>(groundingLevelsCompletionLinker);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        groundProgressLevelObjects = new List<LevelObject>(gameData.groundinLevelObjects);

        groundingLevelsCompletionLinker = new List<LevelCompletionLinker>(gameData.groundingLevelCompletionLinker);

        foreach (LevelCompletionLinker Linker in groundingLevelsCompletionLinker)
        {
            if (Linker.levelObject != null)
            {
                Linker.levelObject.SetCompletionStatus(Linker.IsLevelDone);
            }
        }
    }

}

