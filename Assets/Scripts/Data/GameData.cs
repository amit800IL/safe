using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public List<LevelObject> logicLevelObjects = new List<LevelObject>();
    public List<LevelObject> groundinLevelObjects = new List<LevelObject>();

    public float pourImageFill = 0f;
}
