using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{
    public static Action<List<LevelObject>, List<LevelCompletionLinker>> OnLevelDone { get; set; }

    [SerializeField][HideInInspector] private bool isLevelDone = false;
    public bool IsLevelDone => isLevelDone;
    [field: SerializeField] public LevelCompletionLinker LevelCompletionLinker { get; private set; }

    private void Start()
    {
        OnLevelDone += OnLevelEnded;
    }

    public bool IsLevelOpen()
    {
        return isLevelDone;
    }

    public void SetCompletionStatus(bool isDone)
    {
        isLevelDone = isDone;
    }


    private void OnLevelEnded(List<LevelObject> levelObjects, List<LevelCompletionLinker> completionLinkers)
    {
        if (!levelObjects.Contains(this))
            levelObjects.Add(this);

        if (!completionLinkers.Contains(LevelCompletionLinker) && !IsLevelDone)
        {
            isLevelDone = true;

            LevelCompletionLinker = new LevelCompletionLinker(IsLevelDone, this);

            completionLinkers.Add(LevelCompletionLinker);
        }

        DataSavingManager.Instance.SaveGame();
    }
}

[System.Serializable]
public class LevelCompletionLinker
{
    public bool IsLevelDone = false;
    public LevelObject levelObject;

    public LevelCompletionLinker(bool IsLevelDone, LevelObject levelObject)
    {
        this.IsLevelDone = IsLevelDone;
        this.levelObject = levelObject;
    }
}