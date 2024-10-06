using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GroundinData : GameData
{
    public List<LevelObject<GroundingLevelObject>> levelObjects = new List<LevelObject<GroundingLevelObject>>();

    public float pourImageFill = 0f;

    public GroundinData()
    {
        LevelIndex = LevelObjectID.GroundingLevel;
    }
}
