using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{

    public static Action<List<LevelCompletionLinker>> OnLevelDone { get; set; }
    [field: SerializeField] public LevelCompletionLinker LevelCompletionLinker { get; set; }

    [SerializeField] private LevelObjectSO levelObjectSO;


    private void Start()
    {
        OnLevelDone += OnLevelEnded;
    }

    public bool IsLevelOpen()
    {
        return LevelCompletionLinker.IsLevelDone;
    }

    private void OnLevelEnded(List<LevelCompletionLinker> completionLinkers)
    {
        if (!completionLinkers.Contains(LevelCompletionLinker) && !LevelCompletionLinker.IsLevelDone)
        {
           LevelCompletionLinker.IsLevelDone = levelObjectSO.IsLevelDone;

            LevelCompletionLinker = new LevelCompletionLinker(LevelCompletionLinker.IsLevelDone, levelObjectSO);

            completionLinkers.Add(LevelCompletionLinker);
        }

        DataSavingManager.Instance.SaveGame();
    }
}

[System.Serializable]
public class LevelCompletionLinker
{
    public bool IsLevelDone = false;
    public LevelObjectSO levelObject;

    public LevelCompletionLinker(bool IsLevelDone, LevelObjectSO levelObject)
    {
        this.IsLevelDone = IsLevelDone;
        this.levelObject = levelObject;
    }
}