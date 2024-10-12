using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "LogicQuestionLevel", menuName = "ScriptableObjects/LogicQuestions")]
public class LogicQuestionsSO : ScriptableObject
{
    [RTLText]
    public string questionText;

    [RTLText]
    public List<string> buttonxText = new List<string>();

    public int CorrectIndex;
}
