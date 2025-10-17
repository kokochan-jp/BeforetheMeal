using UnityEngine;
using System.Collections;

public class NotesCollider : MonoBehaviour
{
    [Header("Hit visuals")]
    public Sprite cutPot;                  
    public float hitShowDuration = 0.15f;  

    [Header("Input")]
    public KeyCode keyToPress = KeyCode.Space;

    // runtime
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;
    private bool canBePressed = false;
    private bool wasHit = false;


    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
            originalSprite = spriteRenderer.sprite;
    }

    void OnEnable()
    {
        // Reset state when (re)used from pool
        wasHit = false;
        canBePressed = false;

        if (spriteRenderer != null)
            spriteRenderer.sprite = originalSprite;

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = true;
    }

    void Update()
    {
        if (!wasHit && canBePressed && Input.GetKeyDown(keyToPress))
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        wasHit = true;

        if (spriteRenderer != null && cutPot != null)
            spriteRenderer.sprite = cutPot;
            

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false; // prevent double hits

        GameManager.instance.NoteHit();


        // Show cut sprite briefly, then deactivate (returns to pool)
        StartCoroutine(HitThenDisable());
    }

    private IEnumerator HitThenDisable()
    {
        yield return new WaitForSeconds(hitShowDuration);

        // Deactivate instead of Destroy so pooling can reuse this object
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Activator"))
        {
            canBePressed = true;
            wasHit = false; // ensure fresh state on enter
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Activator"))
        {
            canBePressed = false;
            // intentionally no miss handling (per your request)
        }
    }
}
