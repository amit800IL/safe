using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelObjectsContainer : MonoBehaviour, ISavable
{
    [SerializeField] private LevelObjectID levelObjectContainerIndex;

    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject> progressLevelobjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> levelObjects = new List<LevelObject>();

    private void Start()
    {
        DataSavingManager.Instance.LoadGame(levelObjectContainerIndex);
    }

    public void ActivateLevels()
    {
        DataSavingManager.Instance.LoadGame(levelObjectContainerIndex);

        foreach (LevelObject levelObj in progressLevelobjects)
        {
            if (levelObj != null)
            {
                levelObj.gameObject.SetActive(false);
            }
        }

        progressLevelobjects.Last().gameObject.SetActive(true);
    }

    public void RegisterLevelEnd()
    {
        for (int i = 0; i <= progressLevelobjects.Count; i++)
        {
            if (!progressLevelobjects.Contains(levelObjects[i]))
            {
                LevelButtonsEvents.OnLevelDone.Invoke(i, progressLevelobjects);
                break;
            }
        }

        DataSavingManager.Instance.SaveGame(levelObjectContainerIndex);
    }
    public void SaveData(ref GameData gameData)
    {
        if (gameData is GroundinData)
        {
            GroundinData groundinData = gameData as GroundinData;

            if (levelObjectContainerIndex == LevelObjectID.GroundingLevel)
            {
                groundinData.levelObjects = progressLevelobjects;
            }

        }
        else if (gameData is LogicalQuestionData)
        {
            LogicalQuestionData logicalQuestionData = gameData as LogicalQuestionData;

            if (levelObjectContainerIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions)
            {
                logicalQuestionData.levelObjects = progressLevelobjects;
            }
        }

    }

    public void LoadData(GameData gameData)
    {
        if (gameData is GroundinData)
        {
            GroundinData groundinData = gameData as GroundinData;

            if (levelObjectContainerIndex == LevelObjectID.GroundingLevel)
            {
                progressLevelobjects = groundinData.levelObjects;
            }
        }
        else if (gameData is LogicalQuestionData)
        {
            LogicalQuestionData logicalQuestionData = gameData as LogicalQuestionData;

            if (levelObjectContainerIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions)
            {
                progressLevelobjects = logicalQuestionData.levelObjects;
            }
        }
    }

    public void RegisterPrecenet()
    {
        if (levelObjects != null && levelObjects.Count > 0)
        {
            LevelCollectivePrecent = 100 / levelObjects.Count;
        }
    }

}

public enum LevelObjectID
{
    GroundingLevel,
    LogicalAndMultipleChoiceQuestions,
}