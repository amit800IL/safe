using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    [Header("Logic Level")]

    public List<LevelCompletionLinker> logicLevelCompletionLinker = new List<LevelCompletionLinker>();

    [Header("Grounding Level")]

    public List<LevelCompletionLinker> groundingLevelCompletionLinker = new List<LevelCompletionLinker>();

    [Header("Breathing Level")]

    public List<LevelCompletionLinker> breathingLevelCompletionLinker = new List<LevelCompletionLinker>();

    public float pourImageFill = 0f;

    
}
