using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    [Header("Logic Levels")]

    public List<LevelCompletionLinker> logicLevelCompletionLinker = new List<LevelCompletionLinker>();

    [Header("Grounding Levels")]

    public List<LevelCompletionLinker> groundingLevelCompletionLinker = new List<LevelCompletionLinker>();

    [Header("Breathing Levels")]

    public List<LevelCompletionLinker> breathingLevelCompletionLinker = new List<LevelCompletionLinker>();

    [Header("Support Levels")]

    public List<LevelCompletionLinker> supportLevelCompletionLinker = new List<LevelCompletionLinker>();

    public float pourImageFill = 0f;

    
}
