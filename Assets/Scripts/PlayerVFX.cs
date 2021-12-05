using UnityEngine.Audio;
using UnityEngine;
using ElRaccoone.Tweens;

public class PlayerVFX : MonoBehaviour {

    public Player player;
    public Color chadBgColor;
    public ParticleSystem deathParticles;
    public AudioMixer mixer;
    public Cinemachine.CinemachineVirtualCamera cam;


    private Color backgroundColor;

    private void CameraFX() {
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, backgroundColor, Time.deltaTime * 5f);
    }

    public void Death() {
        deathParticles.Play();
    }

    public void BecomeChad() {
        mixer.FindSnapshot("Chad").TransitionTo(0.5f);
        gameObject.TweenValueFloat(15, 1, (w) => cam.m_Lens.OrthographicSize = w).SetFrom(10);
    }

    public void BecomeVirgin() {
        mixer.FindSnapshot("Default").TransitionTo(0.5f);
        gameObject.TweenValueFloat(10, 1, (w) => cam.m_Lens.OrthographicSize = w).SetFrom(15);
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
