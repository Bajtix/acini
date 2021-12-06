using System.Collections.Generic;
using UnityEngine;

public class SwarmEnemy : SyncedEnemy {
    public SwarmSubEnemy swarmSub;
    public List<Vector2> shape;
    public float scale = 1f;

    private int frame;
    private List<SwarmSubEnemy> swarm;

    protected override void Start() {
        base.Start();
        swarm = new List<SwarmSubEnemy>();
        for (int i = 0; i < shape.Count; i++) {
            var w = Instantiate(swarmSub.gameObject).GetComponent<SwarmSubEnemy>();
            w.Initialize(this); // i am their master, they shall listen to me and me only!
            swarm.Add(w);
        }
    }

    public void MasterImDead(SwarmSubEnemy me) {
        swarm.Remove(me);
        if (swarm.Count == 0) {
            Die();
        }
    }

    protected override void OnEveryBeat() {
        base.OnEveryBeat();
        frame++;
        for (int i = 0; i < swarm.Count; i++) {
            swarm[i].SetGoal(shape[
                (frame + i) % shape.Count] * scale
            );
        }
    }
}
