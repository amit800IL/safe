using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject<T> : MonoBehaviour where T : LevelObject<T>
{
    public static Action<int, List<LevelObject<T>>> OnLevelDone { get; set; }

    [SerializeField] protected int LevelNumber;
    protected virtual void Start()
    {
       OnLevelDone += OnLevelEnded;
    }

    protected virtual void OnLevelEnded(int levelIndex, List<LevelObject<T>> levelObjects)
    {
        if (!levelObjects.Contains(this))
            levelObjects.Add(this);
    }
}
