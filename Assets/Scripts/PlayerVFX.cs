using UnityEngine.Audio;
using UnityEngine;
using ElRaccoone.Tweens;

public class PlayerVFX : MonoBehaviour {

    public Player player;
    public Color chadBgColor;
    public ParticleSystem deathParticles;
    public AudioMixer mixer;
    public float normalFov = 12, chadFov = 20;
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
        gameObject.TweenValueFloat(chadFov, 1, (w) => cam.m_Lens.OrthographicSize = w).SetFrom(normalFov);
    }

    public void BecomeVirgin() {
        mixer.FindSnapshot("Default").TransitionTo(0.5f);
        gameObject.TweenValueFloat(normalFov, 1, (w) => cam.m_Lens.OrthographicSize = w).SetFrom(chadFov);
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
