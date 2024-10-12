using System.Collections.Generic;
using UnityEngine;


public class GroundingLevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject> groundingLevelObjects = new List<LevelObject>();

    [SerializeField] private List<LevelCompletionLinker> groundingLevelsCompletionLinker = new List<LevelCompletionLinker>();

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
        if (gameData == null) return;

        gameData.groundingLevelCompletionLinker = new List<LevelCompletionLinker>(groundingLevelsCompletionLinker);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        groundingLevelsCompletionLinker = new List<LevelCompletionLinker>(gameData.groundingLevelCompletionLinker);

        for (int i = 0; i < groundingLevelsCompletionLinker.Count; i++)
        {
            if (groundingLevelsCompletionLinker[i] != null)
            {
                groundingLevelObjects[i].LevelCompletionLinker = groundingLevelsCompletionLinker[i];
            }
        }
    }

}

