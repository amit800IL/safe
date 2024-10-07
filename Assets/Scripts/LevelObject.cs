using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour 
{
    public static Action<int, List<LevelObject>> OnLevelDone { get; set; }

    [SerializeField] protected int LevelNumber;
    protected virtual void Start()
    {
       OnLevelDone += OnLevelEnded;
    }

    protected virtual void OnLevelEnded(int levelIndex, List<LevelObject> levelObjects)
    {
        if (!levelObjects.Contains(this))
            levelObjects.Add(this);
    }
}
