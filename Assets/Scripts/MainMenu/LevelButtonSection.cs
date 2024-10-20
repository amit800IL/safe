using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSection : MonoBehaviour
{
    [SerializeField] private Canvas MainMenuCanvas;
    [SerializeField] private GameObject[] objectToChangeActiveState;
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
        foreach (GameObject obj in objectToChangeActiveState)
        {
            obj.gameObject.SetActive(true);
        }


        LevelSection.SetActive(true);

        levelStartScreen.SetActive(true);

        MainMenuCanvas.gameObject.SetActive(false);
    }

    public void ActivateLevel(int levelIndex)
    {
        foreach (LevelObject level in levelObjects)
        {
            levelStartScreen.SetActive(false);
            level.gameObject.SetActive(false);
        }

        foreach (GameObject obj in objectToChangeActiveState)
        {
            obj.gameObject.SetActive(true);
        }

        for (int i = 0; i < levelObjects.Length; i++)
        {
            if (i == levelIndex)
            {
                levelObjects[i].gameObject.SetActive(true);
                break;
            }
        }

        LevelSection.SetActive(true);

        MainMenuCanvas.gameObject.SetActive(false);
    }
}
