using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LevelObjectData", menuName = "LevelObject/LevelObjectData")]
public class LevelObjectSO : ScriptableObject
{
    public int LevelHashCode;
    public bool IsLevelDone = true;
}
