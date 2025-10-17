using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{

    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public AudioSource knifeSound;

    public KeyCode keyToPress;

    private bool noteInZone = false;
    private GameObject currentNote;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            theSR.sprite = pressedImage;
            knifeSound.Play();
        }

        if (Input.GetKeyUp(keyToPress))
        {
            theSR.sprite = defaultImage;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            noteInZone = true;
            currentNote = other.gameObject;
        }
    }

    private void OnTriggerExist2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            noteInZone = false;
            currentNote = null;
        }
    }
}
