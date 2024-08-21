using System.Collections.Generic;
using UnityEngine;

public class LevelObjectsContainer : MonoBehaviour
{
    private int LevelCollectivePrecent;
    [SerializeField] private List<LevelObject> levelObjects = new List<LevelObject>();

    public void RegisterPrecenet()
    {
        if (levelObjects != null && levelObjects.Count > 0)
        {
            LevelCollectivePrecent = 100 / levelObjects.Count;
        }
    }
}
