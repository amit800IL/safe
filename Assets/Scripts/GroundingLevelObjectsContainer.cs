using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class GroundingLevelObjectsContainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    private List<LevelObject> groundProgressLevelObjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> groundingLevelObjects = new List<LevelObject>();
    //public void ActivateLevels()
    //{
    //    DataSavingManager.Instance.LoadGame();

    //    foreach (LevelObject levelObj in groundProgressLevelObjects)
    //    {
    //        if (levelObj != null)
    //        {
    //            levelObj.gameObject.SetActive(false);
    //        }
    //    }

    //    groundProgressLevelObjects.Last().gameObject.SetActive(true);
    //}

    public void RegisterLevelEnd()
    {

        for (int i = 0; i <= groundingLevelObjects.Count; i++)
        {
            if (!groundProgressLevelObjects.Contains(groundingLevelObjects[i]))
            {
                LevelObject.OnLevelDone.Invoke(groundProgressLevelObjects);
                break;
            }
        }

        DataSavingManager.Instance.SaveGame();
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.groundinLevelObjects = new List<LevelObject>(groundProgressLevelObjects);
    }

    public void LoadData(GameData gameData)
    {
        groundProgressLevelObjects = new List<LevelObject>(gameData.groundinLevelObjects);
    }

}

