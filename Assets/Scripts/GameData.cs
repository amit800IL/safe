using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public int LevelIndex;

    public List<LevelObject> levelObjects = new List<LevelObject>();

    public float pourImageFill = 0f;
}
