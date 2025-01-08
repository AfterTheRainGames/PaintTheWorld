using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorImage;
    public Vector2 hotspot;

    void Start()
    {
        Texture2D finalCursorImage = cursorImage;

        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            // Create a smaller version of the cursor image by scaling it down manually
            finalCursorImage = ScaleTexture(cursorImage, cursorImage.width / 4, cursorImage.height / 4);
        }

        hotspot = new Vector2(finalCursorImage.width / 2f, finalCursorImage.height / 2f);
        Cursor.SetCursor(finalCursorImage, hotspot, CursorMode.Auto);
    }

    Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, false);
        for (int y = 0; y < targetHeight; y++)
        {
            for (int x = 0; x < targetWidth; x++)
            {
                Color color = source.GetPixelBilinear((float)x / targetWidth, (float)y / targetHeight);
                result.SetPixel(x, y, color);
            }
        }
        result.Apply();
        return result;
    }
}