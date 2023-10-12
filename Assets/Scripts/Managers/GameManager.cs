using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SavingSystem SavingSystem;
    
    private const string CurrentSaveKey = "currentSave";
    private void Awake()
    {
        var saveFile = SavingSystem.ListSaves().ToList()[0] ?? string.Empty;
        if (!string.IsNullOrEmpty(saveFile))
        {
            SavingSystem.Load(saveFile);
        }
    }

    private void OnApplicationQuit()
    {
        SavingSystem.SaveFileExist(CurrentSaveKey);
    }
}
