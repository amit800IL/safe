using UnityEngine;

public abstract class LevelDataObject : ScriptableObject
{
	public int LevelNumber;
	public string Title;
	public bool IsComplete;
}