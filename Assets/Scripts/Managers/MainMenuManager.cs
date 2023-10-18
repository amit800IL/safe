using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
	public class MainMenuManager : MonoBehaviour
	{
		public LevelManager LevelManager;
		
		public Button[] levelButtons;

		private void Awake()
		{
			LevelManager.OnUnlockedLevel += UpdateButtonsState;
		}

		private void Start()
		{
			UpdateButtonsState();
		}

		private void UpdateButtonsState()
		{
			var managerUnlockedLevels = LevelManager.Levels.FindAll(level => level.GetLevelData().IsComplete).Count;
			for(int i = 0; i < managerUnlockedLevels; i++)
			{
				levelButtons[i].interactable = true;
			}
		}
	}
}
