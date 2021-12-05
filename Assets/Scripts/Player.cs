using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
//this code is fucking cursed
public class Player : MonoBehaviour {

    #region Singleton 
    private static Player instance;
    public static Player Instance {
        get {
            if (instance == null) instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }
    #endregion

    public long score = 0;
    public float speed = 5f;
    public float hunger = 1f;
    public bool alive = true;
    public float hungerDrain = 0.055f;
    public bool isChad = false;
    public PlayerVFX fx;


    private Vector2 movementVector = Vector2.zero;
    private Vector2 input = Vector2.zero;
    private float chadTimer = 0;

    public void Chad(float dur) {
        chadTimer = dur;
        if (!isChad) BecomeChad();
    }

    private void BecomeChad() {
        isChad = true;
        fx.BecomeChad();
    }

    private void BecomeVirgin() {
        isChad = false;
        fx.BecomeVirgin();
    }

    public void Die() {
        GameManager.instance?.Score(score);
        GameUI.Instance.Die();

        alive = false;
        Time.timeScale = 0.2f;

        fx.Death();
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

    public void SetInput(Vector2 input) {
        input.x = Mathf.Round(input.x);
        input.y = Mathf.Round(input.y);
        if (input.magnitude <= 0.05f) {
            input = Vector2.up; // dont stop!
        }
        this.input = input.normalized;
    }

    private void Update() {
        if (!alive) return;

        hunger = Mathf.Clamp01(hunger);
        if (hunger == 0) Die();
        GameUI.Instance.SetHunger(hunger);
        hunger -= hungerDrain * Time.deltaTime; // calculate hunger

        if (chadTimer <= 0) {
            fx.WhileVirgin();
            if (isChad) BecomeVirgin();
        } else {
            chadTimer -= Time.deltaTime;
            fx.WhileChad(chadTimer);
        }

        movementVector = input * speed * Time.deltaTime;

        transform.Translate(movementVector); // movement
    }
}
