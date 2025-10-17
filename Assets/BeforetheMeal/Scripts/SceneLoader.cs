using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuiApp()
    {
        Application.Quit();
    }
}
