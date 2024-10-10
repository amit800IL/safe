using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSavingManager : MonoBehaviour
{
    public static DataSavingManager Instance { get; private set; }

    [SerializeField] private GameData gameData;

    private const string FileName = "DataFile.json";

    private List<ISavable> dataSavingObjects;

    private FileDataHandler fileDataHandler;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        gameData ??= new GameData();
        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataSavingObjects = FindAllDataSavers();
        LoadGame();
    }
    private void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }

    private List<ISavable> FindAllDataSavers()
    {
        IEnumerable<ISavable> dataSavers = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ISavable>();

        return new List<ISavable>(dataSavers);
    }
    public void SaveGame()
    {
        foreach (ISavable saverObject in dataSavingObjects)
        {
            if (saverObject != null)
            {
                saverObject.SaveData(ref gameData);
            }
        }

        fileDataHandler.Save(gameData);
    }

    public void LoadGame()
    {
        this.gameData = fileDataHandler.Load();

        foreach (ISavable saverObject in dataSavingObjects)
        {
            if (saverObject != null)
            {
                saverObject.LoadData(this.gameData);
            }
        }
    }
}