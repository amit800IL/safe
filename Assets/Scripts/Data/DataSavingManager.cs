using System.Collections.Generic;
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
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }

        DontDestroyOnLoad(this.gameObject);

        gameData ??= new GameData();

        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);

        this.dataSavingObjects = new List<ISavable>();
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
        LoadGame();
        SaveGame();
    }
    private void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
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

    public void RegisterSavable(ISavable savable)
    {
        if (!dataSavingObjects.Contains(savable))
        {
            dataSavingObjects.Add(savable);
        }
    }
}