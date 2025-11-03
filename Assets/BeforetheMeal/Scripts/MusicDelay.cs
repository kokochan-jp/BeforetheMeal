using UnityEngine;
using System.Collections;

public class MusicDelay : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayTime = 2f;
    public RhythmSpawner spawner; // assign in Inspector

    void Start()
    {
        audioSource.Pause();
        StartCoroutine(PlayWithDelay());
    }

    IEnumerator PlayWithDelay()
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.Play();
        spawner.StartSpawning(); // tell spawner to start
    }
}
