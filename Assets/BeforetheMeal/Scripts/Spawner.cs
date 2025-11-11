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
    public Transform spawnposition;
    public MusicSheets sheet;

    [Header("Spawn Settings")]
    public float spawnChancePerBeat = 1f;
    public float safetyMarginSeconds = 1f;
    public float maxJitterSeconds = 0.06f;
    public float stopSecondsBeforeEnd = 3f;

    private float secondsPerBeat;
    private float nextSpawnTime;
    private int index = 0;

 

    void Awake()
    {
        if (spawnposition != null)
        {
            baseSpawnX = spawnposition.position.x;
            spawnY = spawnposition.position.y;
        }

        enabled = false; // disable until MusicDelay triggers it
    }


    void Start()
    {
        secondsPerBeat = 60f / bpm;
        nextSpawnTime = Time.time + safetyMarginSeconds;
    }

    /* private int count = 0; */

    void Update()
    {
        if (!musicSource.isPlaying) return;

        // Stop spawning a few seconds before the music ends
        if (musicSource.time >= musicSource.clip.length - stopSecondsBeforeEnd)
            return;

        if (Time.time >= nextSpawnTime)
        {
            if (sheet != null)
            {
                /*Debug.Log("Spawning item # " + ++count);
                int spawnCount = Mathf.RoundToInt(spawnChancePerBeat);
                SpawnPotatoes(spawnCount);*/

                if (index < sheet.level.Count)
                {
                    var beattype = sheet.level[index];
                    if (beattype == MusicSheets.beattype.Quarter)
                    {
                        SpawnPotatoes(1);
                    }
                    else if (beattype == MusicSheets.beattype.Eighth)
                    {
                        SpawnPotatoes(2);
                    }
                    else if (beattype == MusicSheets.beattype.Double)
                    {
                        SpawnPotatoes(2);
                    }
                        index++;
                }
            }
            else
            {

                int spawnCount = Mathf.RoundToInt(spawnChancePerBeat);
                SpawnPotatoes(spawnCount);
            }

            nextSpawnTime += secondsPerBeat;
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
    public void StartSpawning()
    {
        secondsPerBeat = 60f / bpm;
        nextSpawnTime = Time.time + safetyMarginSeconds;
        enabled = true;
    }

}
