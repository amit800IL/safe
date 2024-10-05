using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public LevelObjectID LevelIndex;

    public List<LevelObject> levelObjects = new List<LevelObject>();

    public float pourImageFill = 0f;

    public GameData Clone()
    {
        GameData data = new GameData();

        data.LevelIndex = this.LevelIndex;
        data.pourImageFill = this.pourImageFill;

        foreach (LevelObject levelObj in this.levelObjects)
        {
            if (levelObj != null)
            {
                data.levelObjects.Add(levelObj);
            }
        }

        return data;
    }
}
