using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BreathingLevel", menuName = "ScriptableObjects/BreathingLevel")]
public class BreathingLevelSO : ScriptableObject
{

    [Header("Breathing In")]

    [RTLText]
    public string BreathingInText;

    public float BreathingInTimer = 2.5f;
    public Sprite BreathingInSprite;

    [Header("Holding Breath")]

    [RTLText]
    public string HoldingBreathText;

    public float HoldingBreathTimer = 2.5f;
    public Sprite HoldingBreathSprite;

    [Header("Breathing Out")]

    [RTLText]
    public string BreathingOutText;

    public float BreathingOutTimer = 2.5f;
    public Sprite BreathingOutSprite;
}
