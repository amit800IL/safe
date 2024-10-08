using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingLevelObjectsCotainer : MonoBehaviour, ISavable
{
    private int LevelCollectivePrecent;

    private List<LevelObject> BreathingProgressLevelobjects = new List<LevelObject>();

    [SerializeField] private List<LevelObject> BreathingLevelObjects = new List<LevelObject>();
    public void LoadData(GameData gameData)
    {
        throw new System.NotImplementedException();
    }

    public void SaveData(ref GameData gameData)
    {
        throw new System.NotImplementedException();
    }

}
