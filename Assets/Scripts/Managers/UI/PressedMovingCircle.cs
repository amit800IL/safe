using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PressedMovingCircle : PressedMovingObject
{
    public float amplitude = 1f;  // Amplitude of the figure-eight


    /// <summary>
    /// moving the object in the shape of infinity
    /// </summary>
    public override void MoveObject()
    {
        // Calculate the new position based on a figure-eight pattern
        float x = Mathf.Sin(base._timePassedTimer) * amplitude;
        float y = Mathf.Sin(_timePassedTimer * 2f) * (amplitude / 2f);  // Adjust the frequency for the y-axis

        // Set the new position of the circle
        transform.position = new Vector3(x, y, 0);
    }
    new private void Update()
    {
        base.Update();
        MoveObject();
    }
}
