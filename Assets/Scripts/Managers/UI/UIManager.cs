using UnityEngine;

public class UIManager : MonoBehaviour
{
	public static UIManager Instance;
	[SerializeField] private LevelManager _levelManager;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	/// <summary>
	/// Event called when the player pressed on a level button in the level map.
	/// </summary>
	/// <param name="pressedLevelIndex"></param>
	public void ActivateLevelPanel(int pressedLevelIndex)
	{
		int levelIndex = pressedLevelIndex;

		if (IsLevelValid(levelIndex))
		{
			var level = LevelDataProviderByIndex(levelIndex);
			level.InitData();
			level.GetUIPanel().SetActive(true);
		}
	}

	public void BackToMenuPanel()
	{
		var pressedLevelBtn = _levelManager.CurrentPressedLevelBTN;
		if (pressedLevelBtn >= 0 && pressedLevelBtn < _levelManager.Levels.Count)
		{
			var level = LevelDataProviderByIndex(pressedLevelBtn);
			level.GetUIPanel().SetActive(false);
			_levelManager.UnlockNextLevel();
		}
	}
	
	private ILevelDataProvider LevelDataProviderByIndex(int levelIndex)
	{
		var index = _levelManager.Levels.FindIndex(level => level.GetLevelData().LevelNumber == levelIndex);
		var level = _levelManager.Levels[index];
		return level;
	}

	private bool IsLevelValid(int levelIndex)
	{
		return levelIndex >= 0 && levelIndex < _levelManager.Levels.Count &&
		       _levelManager.HasLevelOpened(levelIndex);
	}
}
