using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PressedMovingObject : MonoBehaviour
{
    [SerializeField] protected float _speed;
    [SerializeField] protected float _ZoneTimeLeft;
    [SerializeField] protected float _playerHasToPressTimer;
    //[SerializeField] protected float _pressedTime;

    protected bool _pressedOnObject = false;
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _pressedOnObject = true;
        if (Input.GetMouseButtonUp(0))
            _pressedOnObject = false;
    }
    public abstract void MoveObject();
}
