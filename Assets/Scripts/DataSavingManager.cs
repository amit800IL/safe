using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataSavingManager : MonoBehaviour
{
    public static DataSavingManager Instance { get; private set; }

    Dictionary<LevelObjectID, GameData> levelObjectDataLinker = new Dictionary<LevelObjectID, GameData>();

    [SerializeField] private GameData gameData;

    private const string FileName = "DataFile";

    private List<ISavable> dataSavingObjects;

    private FileDataHandler fileDataHandler;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        gameData = new GameData();
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        this.dataSavingObjects = FindAllDataSavers();
        LoadGame(gameData.Clone().LevelIndex);
    }

    private List<ISavable> FindAllDataSavers()
    {
        IEnumerable<ISavable> dataSavers = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ISavable>();

        return new List<ISavable>(dataSavers);
    }
    public void SaveGame(LevelObjectID levelIndex)
    {
        gameData.LevelIndex = levelIndex;

        foreach (ISavable saverObject in dataSavingObjects)
        {
            if (saverObject != null)
            {
                saverObject.SaveData(ref gameData);
            }
        }

        GameData gameDataClone = gameData.Clone();
        fileDataHandler.Save(gameDataClone);

        levelObjectDataLinker[levelIndex] = gameDataClone;
    }

    public void LoadGame(LevelObjectID levelIndex)
    {
        gameData.LevelIndex = levelIndex;

        gameData.Clone().LevelIndex = levelIndex;

        if (levelObjectDataLinker.TryGetValue(levelIndex, out GameData loadedGameData))
        {
            this.gameData = loadedGameData.Clone();

        }
        else
        {
            this.gameData = fileDataHandler.Load();

            levelObjectDataLinker[levelIndex] = this.gameData.Clone();
        }

        foreach (ISavable saverObject in dataSavingObjects)
        {
            if (saverObject != null)
            {
                saverObject.LoadData(this.gameData);
            }
        }
    }
}