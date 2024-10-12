using UnityEngine;


[CreateAssetMenu(fileName = "LevelObjectData", menuName = "LevelObject/LevelObjectData")]
public class LevelObjectSO : ScriptableObject
{
    [HideInInspector] public bool IsLevelDone = true;
}
