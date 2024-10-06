using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LogicalQuestionData : GameData
{
    public List<LevelObject> levelObjects = new List<LevelObject>();
    public LogicalQuestionData()
    {
        LevelIndex = LevelObjectID.LogicalAndMultipleChoiceQuestions;
    }
}
