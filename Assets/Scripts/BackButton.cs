using UnityEngine;

public class BackButton : MonoBehaviour
{
    [SerializeField] private LevelObject[] levelObjects;

    private void Start()
    {
        levelObjects = FindObjectsOfType<LevelObject>();
    }

    public void BackToMenu()
    {
        foreach (LevelObject levelObject in levelObjects)
        { 
            levelObject.gameObject.SetActive(false);
        }
    }
}
