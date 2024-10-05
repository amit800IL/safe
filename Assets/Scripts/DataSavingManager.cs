using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataSavingManager : MonoBehaviour
{
    public static DataSavingManager Instance { get; private set; }

    Dictionary<int, GameData> levelObjectDataLinker = new Dictionary<int, GameData>();

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

        gameData ??= new GameData();
    }


    private void Start()
    {
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        this.dataSavingObjects = FindAllDataSavers();

        LoadGame(gameData.LevelIndex);
    }

    private List<ISavable> FindAllDataSavers()
    {
        IEnumerable<ISavable> dataSavers = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ISavable>();

        return new List<ISavable>(dataSavers);
    }
    public void SaveGame(int levelIndex)
    {
        gameData.LevelIndex = levelIndex;

        foreach (ISavable saverObject in dataSavingObjects)
        {
            if (saverObject != null)
            {
                saverObject.SaveData(ref gameData);
            }
        }

        fileDataHandler.Save(gameData);

        levelObjectDataLinker[levelIndex] = gameData;
    }

    public void RegisterIndex(int levelIndex)
    {
        gameData.LevelIndex = levelIndex;

        levelObjectDataLinker[levelIndex] = gameData;
    }

    public void LoadGame(int levelIndex)
    {
        gameData.LevelIndex = levelIndex;

        if (levelObjectDataLinker.TryGetValue(levelIndex, out GameData loadedGameData))
        {
            this.gameData = loadedGameData;
        }
        else
        {
            this.gameData = fileDataHandler.Load();

            levelObjectDataLinker[levelIndex] = this.gameData;
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