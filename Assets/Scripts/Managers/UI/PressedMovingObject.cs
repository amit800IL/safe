using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PressedMovingObject : MonoBehaviour
{
    [SerializeField] protected float _speed;

    /// <summary>
    /// in case the player moved the finger outside of the object, this time will give him a chance to currect himself. like 0.3
    /// </summary>
    [SerializeField] protected float _ZoneTimeLeft;
    [SerializeField] protected float _playerHasToPressTimer;
    protected float _timePassedTimer;
    //[SerializeField] protected float _pressedTime;

    protected bool _pressedOnObject = false;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _pressedOnObject = true;
        if (Input.GetMouseButtonUp(0))
            _pressedOnObject = false;
        _timePassedTimer += Time.deltaTime * _speed;
    }
    public abstract void MoveObject();
}
