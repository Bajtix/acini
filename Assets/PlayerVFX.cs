using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour {

    public Color chadBgColor;

    private bool isChad;

    private Color backgroundColor;

    private void CameraFX() {
        if (!isChad)
            backgroundColor = Color.HSVToRGB((Mathf.Abs(transform.position.magnitude) / 100f) % 1, 0.25f, 0.227f);
        else
            backgroundColor = chadBgColor;

        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, backgroundColor, Time.deltaTime * 5f);
    }

    private void Update() {
        isChad = Player.instance.isChad;
    }
}
