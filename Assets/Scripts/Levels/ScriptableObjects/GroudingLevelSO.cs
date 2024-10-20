using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundingWordsLevel", menuName = "LevelObjects/GroundingLevel")]
public class GroundingLevelSO : LevelObjectSO
{
    [RTLText]
    public string questionText;

    [RTLText]
    public List<string> buttonxText = new List<string>();
}
