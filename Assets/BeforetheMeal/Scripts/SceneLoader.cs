using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        StartCoroutine(DelayGoToScene(sceneName));
    }

    private IEnumerator DelayGoToScene(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void QuiApp()
    {
        Application.Quit();
    }
}
