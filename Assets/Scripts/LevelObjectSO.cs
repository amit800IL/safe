using UnityEngine;


[CreateAssetMenu(fileName = "LevelObjectData", menuName = "LevelObject/LevelObjectData")]
public class LevelObjectSO : ScriptableObject
{
    public int LevelHashCode;
    [HideInInspector] public bool IsLevelDone = true;
}
