using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSection : MonoBehaviour
{
    [SerializeField] private GameObject buttonsSection;
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject LevelSection;
    [SerializeField] private GameObject levelStartScreen;
    [SerializeField] private LevelObject[] levelObjects;
    [SerializeField] private Button[] levelsButtons;

    private void Start()
    {
        DataSavingManager.Instance.LoadGame();

        for (int i = 0; i < levelObjects.Length; i++)
        {
            if (levelObjects[i].IsLevelOpen() && levelObjects[i] != null)
            {
                levelsButtons[i].interactable = true;
            }
            else
            {
                levelsButtons[i].interactable = false;
            }
        }
    }

    public void OpenSectionStart()
    {
        backButton.gameObject.SetActive(true);

        LevelSection.SetActive(true);

        levelStartScreen.SetActive(true);

        buttonsSection.SetActive(false);

        DataSavingManager.Instance.LoadGame();

    }

    public void ActivateLogicLevel(LevelObject levelObject)
    {
        foreach (LevelObject level in levelObjects)
        {
            levelStartScreen.SetActive(false);
            level.gameObject.SetActive(false);
        }

        backButton.gameObject.SetActive(true);

        levelObject.gameObject.SetActive(true);

        LevelSection.SetActive(true);

        buttonsSection.SetActive(false);

        DataSavingManager.Instance.LoadGame();

    }
}
