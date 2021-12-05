using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorFlasher : MonoBehaviour
{
    public new SpriteRenderer renderer;

    public Color[] flashColors;
    public float addRotation = 0f;

    private int clr;

    public void Next()
    {
        clr++;
        if (clr >= flashColors.Length) clr = 0;

        renderer.color = flashColors[clr];

        transform.Rotate(0, 0, addRotation);
    }
}
