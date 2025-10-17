using System.Collections.Generic;
using UnityEngine;

public class RhythmSpawner : MonoBehaviour
{
    [Header("References")]
    public AudioSource musicSource;

    [Header("Potato Settings")]
    public float bpm = 91f;
    public float baseSpawnX = -8f;
    public float minHorizontalSpacing = 0.8f; // Minimum distance between potatoes
    public float spawnY = -3f;
    public float moveSpeed = 5f;

    [Header("Spawn Settings")]
    public float spawnChancePerBeat = 1f;
    public float safetyMarginSeconds = 1f;
    public float maxJitterSeconds = 0.06f;
    public float stopSecondsBeforeEnd = 3f;

    private float secondsPerBeat;
    private float nextSpawnTime;

    void Start()
    {
        secondsPerBeat = 60f / bpm;
        nextSpawnTime = Time.time + safetyMarginSeconds;
    }

    void Update()
    {
        if (!musicSource.isPlaying) return;

        // Stop spawning a few seconds before the music ends
        if (musicSource.time >= musicSource.clip.length - stopSecondsBeforeEnd)
            return;

        if (Time.time >= nextSpawnTime)
        {
            int spawnCount = Mathf.RoundToInt(spawnChancePerBeat);
            SpawnPotatoes(spawnCount);

            // Add rhythmic jitter for variety
            nextSpawnTime += secondsPerBeat + Random.Range(-maxJitterSeconds, maxJitterSeconds);
        }
    }

    void SpawnPotatoes(int count)
    {
        if (count <= 0) return;

        // Adjust spacing based on number of potatoes
        float spacing = Mathf.Max(minHorizontalSpacing, 1f / Mathf.Max(1, count) * 2f); // Example scaling
        float totalWidth = (count - 1) * spacing;
        float startX = baseSpawnX - totalWidth / 2f;

        // Create positions list
        List<float> positions = new List<float>();
        for (int i = 0; i < count; i++)
        {
            positions.Add(startX + i * spacing);
        }

        // Shuffle positions randomly for variety
        for (int i = 0; i < positions.Count; i++)
        {
            int randIndex = Random.Range(0, positions.Count);
            (positions[i], positions[randIndex]) = (positions[randIndex], positions[i]);
        }

        // Spawn each potato
        foreach (float xPos in positions)
        {
            GameObject potato = ObjectPool.SharedInstance.GetPooledObject();
            if (potato != null)
            {
                potato.transform.position = new Vector3(xPos, spawnY, 0f);
                potato.SetActive(true);

                Rigidbody2D rb = potato.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.right * moveSpeed;
                }
            }
        }
    }
}
