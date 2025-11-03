using UnityEngine;
using UnityEngine.EventSystems;

public class CursorHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CursorManager cursorManager;

    void Start()
    {
        cursorManager = FindObjectOfType<CursorManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cursorManager.SetHoverCursor();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursorManager.SetDefaultCursor();
    }
}
