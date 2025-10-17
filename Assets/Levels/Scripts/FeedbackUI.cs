using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackUI : MonoBehaviour
{
    [Header("UI Settings")]
    public Text feedbackText;        // Assign your Text UI object in the Inspector
    public float displayTime = 0.5f; // How long the message stays on screen

    private Coroutine clearRoutine;

    // Call this from ButtonController when player hits or misses
    public void ShowFeedback(string message, Color color)
    {
        feedbackText.text = message;
        feedbackText.color = color;

        if (clearRoutine != null)
            StopCoroutine(clearRoutine);

        clearRoutine = StartCoroutine(ClearTextAfterDelay());
    }

    private IEnumerator ClearTextAfterDelay()
    {
        yield return new WaitForSeconds(displayTime);
        feedbackText.text = "";
    }
}
