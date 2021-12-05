using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : SyncedEnemy
{
    public int everyXBeats;
    private int s_beat;
    public float rotationSpeed = 10f;


    public ProjectileEnemy projectile;

    protected override void OnBeat()
    {
        base.OnBeat();
        s_beat++;
        if (s_beat >= everyXBeats)
        {
            Shoot();
            s_beat = 0;
        }
    }

    protected override void Update()
    {
        base.Update();
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    protected virtual void Shoot()
    {
        Vector3 initial = transform.right;
        for (int i = 0; i < 4; i++)
        {
            var p = Instantiate(projectile.gameObject, transform.position, Quaternion.identity).GetComponent<ProjectileEnemy>();
            p.Shoot(initial);

            initial = Quaternion.Euler(0, 0, 90) * initial;
        }

    }
}