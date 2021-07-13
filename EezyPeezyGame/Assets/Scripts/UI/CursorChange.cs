using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CursorChange : MonoBehaviour
{
    public Texture2D cursorDefault, cursorInteractable;
    public Vector2 hotSpot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorInteractable, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseOver()
    {
        Cursor.SetCursor(cursorInteractable, hotSpot, CursorMode.ForceSoftware);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, CursorMode.ForceSoftware);
    }
}
