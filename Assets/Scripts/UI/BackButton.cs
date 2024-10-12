using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public void BackToMenu()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(BackToMenuCoroutine());
        }
    }

    private IEnumerator BackToMenuCoroutine()
    {
        AsyncOperation asyncSceneLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        DataSavingManager.Instance?.LoadGame();

        while (!asyncSceneLoad.isDone)
        {
            yield return null;
        }
    }
}
