using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SwarmEnemy : SyncedEnemy {
    public SwarmSubEnemy swarmSub;
    public List<Vector2> shape;
    public float scale = 1f;

    public string pointInput;

    [NaughtyAttributes.Button("Import")]
    private void Import() {
        string[] lines = pointInput.Split(';');
        foreach (var l in lines) {
            string x = l.Split(',')[0];
            string y = l.Split(',')[1];

            Vector2 p = new Vector2(float.Parse(x, CultureInfo.InvariantCulture), float.Parse(y, CultureInfo.InvariantCulture));
            shape.Add(p);
        }
    }

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

        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    public void MasterImDead(SwarmSubEnemy me) {
        swarm.Remove(me);
        if (swarm.Count == 0) {
            GameUI.Instance.AnnouncePoints("Swarm killed", scoreReward);
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
