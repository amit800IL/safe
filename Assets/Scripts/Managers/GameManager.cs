using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SavingSystem SavingSystem;
    
    private const string CurrentSaveKey = "currentSave";
    private void Awake()
    {
        if (SavingSystem.SaveFileExist(CurrentSaveKey))
        {
            SavingSystem.Load(CurrentSaveKey);
        }
        else
        {
            LevelManager.Instance.ResetAllLevels();
        }
    }

    public void DeleteSave()
    {
        if (SavingSystem.SaveFileExist(CurrentSaveKey))
        {
            SavingSystem.Delete(CurrentSaveKey);
        }
    }

    public void Save()
    {
        SavingSystem.Save(CurrentSaveKey);
    }

    // private void OnApplicationQuit()
    // {
    //     SavingSystem.Save(CurrentSaveKey);
    // }
}
