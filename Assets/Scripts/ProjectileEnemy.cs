using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : Enemy
{
    private Vector3 direction;
    public float angleSpeed;

    public virtual void Shoot(Vector3 vector)
    {
        direction = vector;
        particles.Play();
    }

    private void Update()
    {
        transform.position += direction * Time.deltaTime * speed;
        transform.Rotate(0, 0, angleSpeed * Time.deltaTime);
    }
}
