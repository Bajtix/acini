using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour {

    public Color chadBgColor;
    public ParticleSystem deathParticles;

    private Player player;
    private Color backgroundColor;

    private void CameraFX() {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, backgroundColor, Time.deltaTime * 5f);
    }

    public void Death() {
        deathParticles.Play();
    }

    public void BecomeChad() {

    }

    public void BecomeVirgin() {

    }

    public void WhileChad(float timer) {
        backgroundColor = chadBgColor;
    }

    public void WhileVirgin() {
        backgroundColor = Color.HSVToRGB((Mathf.Abs(transform.position.magnitude) / 100f) % 1, 0.25f, 0.227f);
    }

    private void Update() {
        CameraFX();
    }
}
