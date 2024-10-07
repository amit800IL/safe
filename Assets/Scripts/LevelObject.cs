using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour 
{
    public static Action<List<LevelObject>> OnLevelDone { get; set; }

    protected virtual void Start()
    {
       OnLevelDone += OnLevelEnded;
    }

    protected virtual void OnLevelEnded(List<LevelObject> levelObjects)
    {
        if (!levelObjects.Contains(this))
            levelObjects.Add(this);
    }
}
