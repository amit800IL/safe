using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSection : MonoBehaviour
{
    [SerializeField] private GameObject buttonsSection;
    [SerializeField] private GameObject LevelSection;
    [SerializeField] private GameObject levelStartScreen;
    [SerializeField] private LevelObject[] levelObjects;
    [SerializeField] private Button[] levelsButtons;

    private void Start()
    {
        for (int i = 0; i < levelObjects.Length; i++)
        {
            if (levelObjects[i].IsLevelOpen())
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
        LevelSection.SetActive(true);

        levelStartScreen.SetActive(true);

        buttonsSection.SetActive(false);
    }

    public void ActivateLogicLevel(LevelObject levelObject)
    {
        foreach (LevelObject level in levelObjects)
        {
            levelStartScreen.SetActive(false);
            level.gameObject.SetActive(false);
        }

        levelObject.gameObject.SetActive(true);

        LevelSection.SetActive(true);

        buttonsSection.SetActive(false);
    }
}
