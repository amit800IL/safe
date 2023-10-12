using UnityEngine;

[System.Serializable]
public class SerializibleVector3
{
    private float x, y, z;

    public SerializibleVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }
}
