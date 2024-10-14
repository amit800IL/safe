using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SupporteExercise", menuName = "LevelObjects/SupportExercise")]
public class SupporteExerciseSO : LevelObjectSO
{
    [RTLText]
    public string ExerciseText;

    [RTLText]
    public string FinishText;
}
