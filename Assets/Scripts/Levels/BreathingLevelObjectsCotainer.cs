using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingLevelObjectsCotainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    private List<LevelObject> BreathingProgressLevelobjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> BreathingLevelObjects = new List<LevelObject>();

    [SerializeField] List<LevelCompletionLinker> breathinglevelCompletionLinkers = new List<LevelCompletionLinker>();

    public void RegisterLevelEnd()
    {
        for (int i = 0; i <= BreathingLevelObjects.Count; i++)
        {
            if (!BreathingProgressLevelobjects.Contains(BreathingProgressLevelobjects[i]))
            {
                LevelObject.OnLevelDone.Invoke(BreathingLevelObjects, breathinglevelCompletionLinkers);
                break;
            }
        }

        DataSavingManager.Instance.SaveGame();
    }
    public void SaveData(ref GameData gameData)
    {
        gameData.groundinLevelObjects = new List<LevelObject>(BreathingLevelObjects);
        gameData.breathingLevelCompletionLinker = new List<LevelCompletionLinker>(breathinglevelCompletionLinkers);
    }

    public void LoadData(GameData gameData)
    {
        BreathingLevelObjects = new List<LevelObject>(gameData.breathingLevelObjects);
        breathinglevelCompletionLinkers = new List<LevelCompletionLinker>(gameData.logicLevelCompletionLinker);

        foreach (LevelCompletionLinker Linker in breathinglevelCompletionLinkers)
        {
            if (Linker.levelObject != null)
            {
                Linker.levelObject.SetCompletionStatus(Linker.IsLevelDone);
            }
        }
    }

}
