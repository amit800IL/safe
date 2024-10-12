using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private LevelObject[] levelObjects;
    [SerializeField] private Button[] menuButtons;

    public void BackToMenu()
    {
        foreach (LevelObject levelObject in levelObjects)
        { 
            levelObject.gameObject.SetActive(false);
        }

        for (int i = 0; i < levelObjects.Length; i++)
        {
            if (levelObjects[i].IsLevelOpen() && levelObjects[i] != null)
            {
                menuButtons[i].interactable = true;
            }
            else
            {
                menuButtons[i].interactable = false;
            }
        }
    }
}
