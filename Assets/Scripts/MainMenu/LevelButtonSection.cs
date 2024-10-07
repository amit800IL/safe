using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSection : MonoBehaviour
{
    [SerializeField] private GameObject buttonsSection;
    [SerializeField] private GameObject LevelSection;
    [SerializeField] private GameObject[] levelObjects;
    public void ActivateLogicLevel(LevelObject levelObject)
    {
        foreach (GameObject level in levelObjects)
        {
            level.gameObject.SetActive(false);
        }

        levelObject.gameObject.SetActive(true);

        LevelSection.SetActive(true);

        buttonsSection.SetActive(false);

        DataSavingManager.Instance.LoadGame();
    }
}
