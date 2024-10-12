using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundingWordsLevel", menuName = "ScriptableObjects/GroundingLevel")]
public class GroundingLevelSO : ScriptableObject
{
    [RTLText]
    public string questionText;

    [RTLText]
    public List<string> buttonxText = new List<string>();
}
