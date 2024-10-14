using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportLevelsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject> SupportLevelObjects = new List<LevelObject>();

    [SerializeField] private List<LevelCompletionLinker> SupportLevelsCompletionLinker = new List<LevelCompletionLinker>();

    private void Awake()
    {
        DataSavingManager.Instance.RegisterSavable(this);
    }

    public void RegisterLevelEnd()
    {
        LevelObject.OnLevelDone?.Invoke(SupportLevelsCompletionLinker);

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        if (gameData == null) return;

        gameData.supportLevelCompletionLinker = new List<LevelCompletionLinker>(SupportLevelsCompletionLinker);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        SupportLevelsCompletionLinker = new List<LevelCompletionLinker>(gameData.supportLevelCompletionLinker);

        for (int i = 0; i < SupportLevelsCompletionLinker.Count; i++)
        {
            if (SupportLevelsCompletionLinker[i] != null)
            {
                SupportLevelObjects[i].LevelCompletionLinker = SupportLevelsCompletionLinker[i];
            }
        }
    }
}
