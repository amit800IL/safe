using System.Collections.Generic;
using UnityEngine;


public class GroundingLevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

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
    private void Awake()
    {
        DataSavingManager.Instance.RegisterSavable(this);
    }
    public void RegisterLevelEnd()
    {
        LevelObject.OnLevelDone?.Invoke(groundingLevelsCompletionLinker);

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.groundingLevelCompletionLinker = new List<LevelCompletionLinker>(groundingLevelsCompletionLinker);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        groundingLevelsCompletionLinker = new List<LevelCompletionLinker>(gameData.groundingLevelCompletionLinker);

        foreach (LevelCompletionLinker Linker in groundingLevelsCompletionLinker)
        {
            if (Linker.levelObject != null)
            {
                Linker.SetCompletionStatus(Linker.IsLevelDone);
            }
        }
    }

}

