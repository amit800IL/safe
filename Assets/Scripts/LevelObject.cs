using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelObject : MonoBehaviour
{
    [SerializeField] private int LevelNumber;
    private void Start()
    {
        LevelButtonsEvents.OnLevelDone += OnLevelEnded;
    }

    public void OnLevelEnded(int levelIndex, List<LevelObject> levelObjects)
    {
        if (!levelObjects.Contains(this))
            levelObjects.Add(this);
    }
}
