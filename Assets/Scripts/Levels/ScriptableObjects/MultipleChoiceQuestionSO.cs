using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MultipleChoiceQuestion", menuName = "LevelObjects/MultipleChoiceQuestion")]
public class MultipleChoiceQuestionSO : LevelObjectSO
{
    [RTLText]
    public string questionText;

    [RTLText]   
    public List<string> choicesText = new List<string>();
}
