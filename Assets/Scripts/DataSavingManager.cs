using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataSavingManager : MonoBehaviour
{
    public static DataSavingManager Instance { get; private set; }

    Dictionary<LevelObjectID, GameData> levelObjectDataLinker = new Dictionary<LevelObjectID, GameData>();
    public Dictionary<LevelObjectID, GameData> LevelObjectDataLinker { get => levelObjectDataLinker; private set => levelObjectDataLinker = value; }

    [SerializeField] private GroundinData groundLevelData;

    [SerializeField] private LogicalQuestionData logicalQuestionData;

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

        if (!levelObjectDataLinker.ContainsKey(LevelObjectID.GroundingLevel))
        {
            levelObjectDataLinker.Add(LevelObjectID.GroundingLevel, groundLevelData);
        }

        if (!levelObjectDataLinker.ContainsKey(LevelObjectID.LogicalAndMultipleChoiceQuestions))
        {
            levelObjectDataLinker.Add(LevelObjectID.LogicalAndMultipleChoiceQuestions, logicalQuestionData);
        }

        this.fileDataHandler = new FileDataHandler(Application.persistentDataPath, FileName);
        this.dataSavingObjects = FindAllDataSavers();


    }

    private List<ISavable> FindAllDataSavers()
    {
        IEnumerable<ISavable> dataSavers = Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<ISavable>();

        return new List<ISavable>(dataSavers);
    }
    public void SaveGame(LevelObjectID levelIndex)
    {
        if (levelIndex == LevelObjectID.GroundingLevel)
        {
            LevelObjectDataLinker[levelIndex] ??= new GroundinData();

            groundLevelData = LevelObjectDataLinker[levelIndex] as GroundinData;

            GameData groundinDataLocal = groundLevelData;

            foreach (ISavable saverObject in dataSavingObjects)
            {
                if (saverObject != null)
                {
                    saverObject.SaveData(ref groundinDataLocal);
                }
            }

            groundLevelData = (GroundinData)groundinDataLocal;

            fileDataHandler.Save(groundLevelData);
        }

        if (levelIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions)
        {
            LevelObjectDataLinker[levelIndex] ??= new LogicalQuestionData();

            logicalQuestionData = LevelObjectDataLinker[levelIndex] as LogicalQuestionData;

            GameData logicalQuestionsDataLocal = logicalQuestionData;

            foreach (ISavable saverObject in dataSavingObjects)
            {
                if (saverObject != null)
                {
                    saverObject.SaveData(ref logicalQuestionsDataLocal);
                }
            }

            logicalQuestionData = (LogicalQuestionData)logicalQuestionsDataLocal;

            fileDataHandler.Save(logicalQuestionData);
        }
    }

    public void LoadGame(LevelObjectID levelIndex)
    {

        if (levelIndex == LevelObjectID.GroundingLevel)
        {
            LevelObjectDataLinker[levelIndex] ??= new GroundinData();

            groundLevelData = LevelObjectDataLinker[levelIndex] as GroundinData;

            GameData groundinDataLocal = groundLevelData;

            foreach (ISavable saverObject in dataSavingObjects)
            {
                if (saverObject != null)
                {
                    saverObject.LoadData(groundinDataLocal);
                }
            }

            groundLevelData = fileDataHandler.Load<GroundinData>();
        }

        if (levelIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions)
        {
            LevelObjectDataLinker[levelIndex] ??= new LogicalQuestionData();

            logicalQuestionData = LevelObjectDataLinker[levelIndex] as LogicalQuestionData;

            GameData logicalQuestionsDataLocal = logicalQuestionData;

            foreach (ISavable saverObject in dataSavingObjects)
            {
                if (saverObject != null)
                {
                    saverObject.LoadData(logicalQuestionsDataLocal);
                }
            }


            logicalQuestionData = fileDataHandler.Load<LogicalQuestionData>();
        }
    }
}