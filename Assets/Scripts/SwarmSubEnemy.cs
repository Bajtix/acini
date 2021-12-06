using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmSubEnemy : Enemy {

    private SwarmEnemy master;
    private Vector2 nextPosition;

    public void Initialize(SwarmEnemy master) {
        transform.parent = master.transform;
        transform.localPosition = Vector3.zero;
        this.master = master;
    }

    public void SetGoal(Vector2 goal) {
        nextPosition = goal;
    }

    protected override void Die() {
        master.MasterImDead(this);
        base.Die();
    }

    private void Update() {
        transform.localPosition = Vector3.Lerp(transform.localPosition, nextPosition, Time.deltaTime * speed);
    }
}