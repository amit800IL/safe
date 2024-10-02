using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataSavingManager : MonoBehaviour
{
    public static DataSavingManager Instance { get; private set; }

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
    }


    private void Start()
    {
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        this.dataSavingObjects = FindAllDataSavers();

        LoadGame();
    }

    private List<ISavable> FindAllDataSavers()
    {
        IEnumerable<ISavable> dataSavers = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>();

        return new List<ISavable>(dataSavers);
    }
    public void SaveGame()
    {
        foreach (ISavable saverObject in dataSavingObjects)
        {
            saverObject.SaveData(ref gameData);
        }

        fileDataHandler.Save(gameData);
    }
    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();

        if (gameData == null)
        {
            gameData = new GameData();
        }

        foreach (ISavable saverObject in dataSavingObjects)
        {
            saverObject.LoadData(gameData);
        }
    }
}
