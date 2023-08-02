using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomMouse : MonoBehaviour
{
    public Texture2D cursorTexture;
    public Vector2 hotspot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotspot, CursorMode.ForceSoftware);
    }
}
