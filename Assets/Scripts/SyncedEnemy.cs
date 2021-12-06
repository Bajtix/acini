using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SyncedEnemy : Enemy {
    public float movementRange = 5;
    private Vector3 nextPos;

    public int beatEvery = 1;
    private int beat;


    protected override void Start() {
        base.Start();
        AudioController.instance.onBeat += OnEveryBeat;
        nextPos = transform.position;
    }

    protected virtual void Update() {
        transform.position = Vector3.Lerp(transform.position, nextPos, speed * Time.deltaTime);
    }

    protected virtual void OnEveryBeat() {
        beat++;
        if (beat >= beatEvery) {
            beat = 0;
            OnBeat();
        }
    }

    protected virtual void OnBeat() {
        nextPos = transform.position + RandomDir() * movementRange;
        GetComponent<ColorFlasher>()?.Next();
    }

    protected Vector3 RandomDir() {
        var r = new Vector3(Random.Range(-1, 2), Random.Range(-1, 2), 0).normalized; ;
        if (r.magnitude == 0) r = Vector3.up;
        return r;
    }

    protected override void Die() {
        AudioController.instance.onBeat -= OnEveryBeat;
        base.Die();
    }
}
