using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedFillingColor : PressedMovingObject
{
    [SerializeField] private Image _fillingColorImage;

    float timePassedTimer;

    public override void MoveObject()
    {
        _fillingColorImage.fillAmount =  0.1f + ((timePassedTimer +=Time.deltaTime) / _playerHasToPressTimer);
    }

    new private void Update()
    {
        base.Update();
        MoveObject();
    }
}
