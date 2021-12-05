using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Food : MonoBehaviour
{
    public float nutrienValue;
    public float aliveTime = 10f;
    public int pointValue;

    public ParticleSystem particles;

    private void Start()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        if (GetComponent<ColorFlasher>()) AudioController.instance.onBeat += GetComponent<ColorFlasher>().Next;

        Destroy(gameObject, aliveTime);
    }

    private void OnDestroy()
    {
        if (GetComponent<ColorFlasher>()) AudioController.instance.onBeat -= GetComponent<ColorFlasher>().Next;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        particles.transform.SetParent(null);
        particles.Play();
        if (other.gameObject.CompareTag("Player"))
        {
            Eat();
        }
        Destroy(gameObject);
    }

    public virtual void Eat()
    {

        Player.instance.Bop();
        Player.instance.hunger += nutrienValue;
        Player.instance.Score(pointValue);

    }
}
