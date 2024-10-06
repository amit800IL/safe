using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelObjectsContainer : MonoBehaviour, ISavable
{
    [SerializeField] private LevelObjectID levelObjectContainerIndex;

    private int LevelCollectivePrecent;

    [SerializeField] private List<LevelObject<LogicalQuestionsLevelObject>> LogicalLevelObjects = new List<LevelObject<LogicalQuestionsLevelObject>>();

    private List<LevelObject<LogicalQuestionsLevelObject>> LogicalLevelProgressObjects = new List<LevelObject<LogicalQuestionsLevelObject>>();

    [SerializeField] private List<LevelObject<GroundingLevelObject>> groundingLevelObjects = new List<LevelObject<GroundingLevelObject>>();

    private List<LevelObject<GroundingLevelObject>> groundingLevelProgressObjects = new List<LevelObject<GroundingLevelObject>>();

    private void Start()
    {
        DataSavingManager.Instance.LoadGame(levelObjectContainerIndex);
    }

    public void ActivateLevels()
    {
        if (levelObjectContainerIndex == LevelObjectID.GroundingLevel && groundingLevelObjects.Count != 0)
        {
            DataSavingManager.Instance.LoadGame(levelObjectContainerIndex);

            foreach (LevelObject<GroundingLevelObject> levelObj in groundingLevelProgressObjects)
            {
                if (levelObj != null)
                {
                    levelObj.gameObject.SetActive(false);
                }
            }

            groundingLevelProgressObjects.Last().gameObject.SetActive(true);

        }

        if (levelObjectContainerIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions && LogicalLevelObjects.Count != 0)
        {
            DataSavingManager.Instance.LoadGame(levelObjectContainerIndex);

            foreach (LevelObject<LogicalQuestionsLevelObject> levelObj in LogicalLevelProgressObjects)
            {
                if (levelObj != null)
                {
                    levelObj.gameObject.SetActive(false);
                }
            }

            LogicalLevelProgressObjects.Last().gameObject.SetActive(true);

        }
    }
    public void RegisterLevelEnd()
    {
        if (levelObjectContainerIndex == LevelObjectID.GroundingLevel && groundingLevelObjects.Count != 0)
        {
            for (int i = 0; i <= groundingLevelObjects.Count; i++)
            {
                if (!groundingLevelProgressObjects.Contains(groundingLevelObjects[i]))
                {
                    LevelObject<GroundingLevelObject>.OnLevelDone.Invoke(i, groundingLevelProgressObjects);
                    break;
                }
            }

            DataSavingManager.Instance.SaveGame(levelObjectContainerIndex);
        }

        if (levelObjectContainerIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions && LogicalLevelObjects.Count != 0)
        {
            for (int i = 0; i <= LogicalLevelObjects.Count; i++)
            {
                if (!LogicalLevelProgressObjects.Contains(LogicalLevelObjects[i]))
                {
                    LevelObject<LogicalQuestionsLevelObject>.OnLevelDone.Invoke(i, LogicalLevelProgressObjects);
                    break;
                }
            }

            DataSavingManager.Instance.SaveGame(levelObjectContainerIndex);
        }

    }
    public void SaveData(ref GameData gameData)
    {
        gameData.LevelIndex = levelObjectContainerIndex;

        if (levelObjectContainerIndex == LevelObjectID.GroundingLevel && groundingLevelObjects.Count != 0)
        {
            GroundinData groundingData = gameData as GroundinData;

            groundingData.levelObjects = groundingLevelProgressObjects;
        }

        if (levelObjectContainerIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions && LogicalLevelObjects.Count != 0)
        {
            LogicalQuestionData logicalQuestionaData = gameData as LogicalQuestionData;

            logicalQuestionaData.levelObjects = LogicalLevelProgressObjects;
        }
    }

    public void LoadData(GameData gameData)
    {
        if (levelObjectContainerIndex == LevelObjectID.GroundingLevel && groundingLevelObjects.Count != 0)
        {
            GroundinData groundingData = gameData as GroundinData;

            groundingLevelProgressObjects = groundingData.levelObjects;
        }

        if (levelObjectContainerIndex == LevelObjectID.LogicalAndMultipleChoiceQuestions && LogicalLevelObjects.Count != 0)
        {
            LogicalQuestionData logicalQuestionaData = gameData as LogicalQuestionData;

            LogicalLevelProgressObjects = logicalQuestionaData.levelObjects;
        }
    }

    public void RegisterPrecenet()
    {
        if (groundingLevelObjects != null && groundingLevelObjects.Count > 0)
        {
            LevelCollectivePrecent = 100 / groundingLevelObjects.Count;
        }
    }

}

public enum LevelObjectID
{
    GroundingLevel,
    LogicalAndMultipleChoiceQuestions,
}