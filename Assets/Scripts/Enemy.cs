using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed = 10f;
    public float hungerDamage;
    public int scoreDamage;
    public float hungerReward;
    public int scoreReward;

    public float aliveTime = 20f;

    public bool dieOnHit = true;

    public ParticleSystem particles;


    protected virtual void Start() {
        StartCoroutine(DestroySelf());
    }

    private IEnumerator DestroySelf() {
        yield return new WaitForSeconds(aliveTime);
        Die();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider2D) {
        if (collider2D.CompareTag("Player")) {
            Player.Instance.Bop();
            if (Player.Instance.isChad) {
                Player.Instance.Eat(hungerReward);
                Player.Instance.Score(scoreReward);
                GameUI.Instance.AnnouncePoints("Hunter", scoreReward);
                Die();
            } else {
                Player.Instance.Damage(hungerDamage);
                Player.Instance.Score(-scoreDamage);
                if (dieOnHit)
                    Die();
            }


        }
    }

    protected virtual void Die() {
        if (particles != null) {
            particles.transform.SetParent(null);
            particles.Play();
        }
        Destroy(gameObject);
    }
}
