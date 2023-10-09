using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressedFillingColor : PressedMovingObject
{
    [SerializeField] private Image _fillingColorImage;

    /// <summary>
    /// filling the image verticly from down to up.
    /// </summary>
    public override void MoveObject()
    {
        _fillingColorImage.fillAmount =  0.1f + ((_timePassedTimer) / _playerHasToPressTimer);
    }

    new private void Update()
    {
        base.Update();
        MoveObject();
    }
}
