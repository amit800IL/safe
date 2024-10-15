using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementLevel", menuName = "LevelObjects/MovementLevel")]
public class MovementLevelSO : LevelObjectSO
{
    public MovementType movementType;
    public float speed;
    public float time;

}

public enum MovementType
{
    InfinityMovement,
    LinearUpAndDownMovement,
    EasedUpAndDownMovement,
}
