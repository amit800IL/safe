using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LogicalQuestionData : GameData
{
    public List<LevelObject<LogicalQuestionsLevelObject>> levelObjects = new List<LevelObject<LogicalQuestionsLevelObject>>();
    public LogicalQuestionData()
    {
        LevelIndex = LevelObjectID.LogicalAndMultipleChoiceQuestions;
    }
}
