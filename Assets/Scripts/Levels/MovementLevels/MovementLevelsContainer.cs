using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLevelsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject> movementLevelObjects = new List<LevelObject>();

    [SerializeField] private List<LevelCompletionLinker> movementLevelsCompletionLinker = new List<LevelCompletionLinker>();

    private void Awake()
    {
        DataSavingManager.Instance.RegisterSavable(this);
    }

    public void RegisterLevelEnd()
    {
        LevelObject.OnLevelDone?.Invoke(movementLevelsCompletionLinker);

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        if (gameData == null) return;

        gameData.movementLevelCompletionLinker = new List<LevelCompletionLinker>(movementLevelsCompletionLinker);
    }

    public void LoadData(GameData gameData)
    {
        if (gameData == null) return;

        movementLevelsCompletionLinker = new List<LevelCompletionLinker>(gameData.movementLevelCompletionLinker);

        for (int i = 0; i < movementLevelsCompletionLinker.Count; i++)
        {
            if (movementLevelsCompletionLinker[i] != null)
            {
                movementLevelObjects[i].LevelCompletionLinker = movementLevelsCompletionLinker[i];
            }
        }
    }
}
