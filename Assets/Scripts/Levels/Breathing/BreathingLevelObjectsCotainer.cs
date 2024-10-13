using System.Collections.Generic;
using UnityEngine;

public class BreathingLevelObjectsCotainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject> BreathingLevelObjects = new List<LevelObject>();

    [SerializeField] private List<LevelCompletionLinker> breathinglevelCompletionLinkers = new List<LevelCompletionLinker>();

    private void Awake()
    {
        DataSavingManager.Instance.RegisterSavable(this);
    }

    public void RegisterLevelEnd()
    {
        LevelObject.OnLevelDone?.Invoke(breathinglevelCompletionLinkers);

        DataSavingManager.Instance.SaveGame();
    }
    public void SaveData(ref GameData gameData)
    {
        if (gameData == null) return;

        gameData.breathingLevelCompletionLinker = new List<LevelCompletionLinker>(breathinglevelCompletionLinkers);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        breathinglevelCompletionLinkers = new List<LevelCompletionLinker>(gameData.breathingLevelCompletionLinker);

        for (int i = 0; i < breathinglevelCompletionLinkers.Count; i++)
        {
            if (breathinglevelCompletionLinkers[i] != null)
            {
                BreathingLevelObjects[i].LevelCompletionLinker = breathinglevelCompletionLinkers[i];
            }
        }
    }
}


