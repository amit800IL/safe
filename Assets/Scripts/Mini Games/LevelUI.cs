using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface ILevelDataProvider
{
	LevelDataObject GetLevelData();
	GameObject GetUIPanel();
	void InitData();
}

public abstract class LevelUI<T> : MonoBehaviour, ISaveable, ILevelDataProvider where T : LevelDataObject
{
	public T LevelData;
	public TextMeshProUGUI Title;
	public Button NextButton;
	
	public LevelDataObject GetLevelData()
	{
		return LevelData;
	}

	public GameObject GetUIPanel()
	{
		return gameObject;
	}

	public virtual void InitData()
	{
		Title.text = LevelData.Title;
	}
	
	[Serializable]
	private struct LevelRecord
	{
		public int LevelNumber;
		public bool IsComplete;
	}
	
	public object CaptureState()
	{
		var record = new LevelRecord()
		{
			LevelNumber = LevelData.LevelNumber,
			IsComplete = LevelData.IsComplete
		};
		return record;
	}
	
	public void RestoreState(object state)
	{
		var record = (LevelRecord)state;
		LevelData.LevelNumber = record.LevelNumber;
		LevelData.IsComplete = record.IsComplete;
	}
}

