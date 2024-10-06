using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundinData : GameData
{
    public List<LevelObject> levelObjects = new List<LevelObject>();

    public float pourImageFill = 0f;

    public GroundinData()
    {
        LevelIndex = LevelObjectID.GroundingLevel;
    }
}
