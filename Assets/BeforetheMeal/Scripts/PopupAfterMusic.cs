using System.Collections;
using UnityEngine;

public class PopupAfterMusic : MonoBehaviour
{
    [Header("References")]
    public AudioSource musicSource;    // Assign your AudioSource
    public GameObject popupWindow;     // Assign your popup GameObject

    private bool hasShownPopup = false;
    private bool musicHasStarted = false;

    void Update()
    {
        // Detect when music starts
        if (musicSource.isPlaying)
        {
            musicHasStarted = true;
        }

        // Detect when music has finished (only after it started)
        if (musicHasStarted && !musicSource.isPlaying && !hasShownPopup)
        {
            hasShownPopup = true;
            StartCoroutine(ShowPopupAfterDelay());
        }
    }

    private IEnumerator ShowPopupAfterDelay()
    {
        yield return new WaitForSeconds(0.5f);
        popupWindow.SetActive(true);
    }
}
