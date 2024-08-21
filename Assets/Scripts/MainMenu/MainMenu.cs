using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
