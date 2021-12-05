using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
//this code is fucking cursed
public class Player : MonoBehaviour {
    public long score = 0;
    public float speed = 5f;
    public float hunger = 1f;
    public bool alive = true;
    public float hungerSpeed = 0.01f;
    public static Player instance;

    private float timeFromLastKeypress = 0;

    private Vector2 movementVector = Vector2.zero;
    private Vector2 input = Vector2.zero;

    public int beatCombo = 0;

    private Color backgroundColor = Color.black;

    public float chadTimer = 0;

    public bool isChad = false;

    private float targetHighpassMusic = -80f;
    private float targetPitchMusic = 1f;

    public ParticleSystem particles;


    public AudioMixer mixerGroup;

    public void Chad(float dur) {
        chadTimer = dur;
        if (!isChad) BecomeChad();
    }

    private void BecomeChad() {
        targetHighpassMusic = -10f;
        targetPitchMusic = 1.05f;
        isChad = true;
    }

    private void BecomeVirgin() {
        targetHighpassMusic = -80f;
        targetPitchMusic = 1f;
        isChad = false;
    }

    private void Awake() {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }

    private void Update() {
        if (!alive) return;

        hunger = Mathf.Clamp01(hunger);
        if (hunger == 0) Die();
        GameUI.Instance.SetHunger(hunger);
        hunger -= hungerSpeed * Time.deltaTime; // calculate hunger

        if (chadTimer <= 0)
            BecomeVirgin();
        else
            chadTimer -= Time.deltaTime;

        timeFromLastKeypress += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)) {
            if (Mathf.Abs(timeFromLastKeypress - AudioController.instance.beatEvery) < AudioController.instance.accuracy) {
                beatCombo++;
                if (beatCombo > 1) {
                    GameUI.Instance.AnnouncePoints("To the beat!", beatCombo);
                    Score(beatCombo);
                }


            } else {
                beatCombo = 0;
            }

            timeFromLastKeypress = 0;

            input = new Vector2(0, 0);

            if (Input.GetKeyDown(KeyCode.W))
                input.y = 1;
            if (Input.GetKeyDown(KeyCode.S))
                input.y = -1;
            if (Input.GetKeyDown(KeyCode.A))
                input.x = -1;
            if (Input.GetKeyDown(KeyCode.D))
                input.x = 1;


        }

        input = Vector3.ClampMagnitude(input, 1);
        movementVector = input * speed * Time.deltaTime;

        float _;
        mixerGroup.GetFloat("Highpass", out _);
        mixerGroup.SetFloat("Highpass", Mathf.Lerp(_, targetHighpassMusic, Time.deltaTime * 10f));
        mixerGroup.GetFloat("Pitch", out _);
        mixerGroup.SetFloat("Pitch", Mathf.Lerp(_, targetPitchMusic, Time.deltaTime * 10f));

        transform.Translate(movementVector); // movement
    }

    public void Die() {
        GameManager.instance?.Score(score);
        GameUI.Instance.Die();

        alive = false;
        Time.timeScale = 0.2f;

        particles.Play();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Bop() {

    }

    public void Damage(float nut) {
        hunger -= nut;

    }

    public void Eat(float nut) {
        hunger += nut;
    }

    public void Score(long amount) {
        score += amount;
        GameUI.Instance.Score(score);
    }
}
