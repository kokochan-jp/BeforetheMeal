using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    public Vector2 hotspot = Vector2.zero;

    private static CursorManager instance;

    void Awake()
    {
        // Make sure there’s only one CursorManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 👈 Keeps it alive across scenes
            SetDefaultCursor();
        }
        else
        {
            Destroy(gameObject); // avoid duplicates when loading new scenes
        }
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    public void SetHoverCursor()
    {
        Cursor.SetCursor(hoverCursor, hotspot, CursorMode.Auto);
    }
}
