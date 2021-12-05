using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    public SpawnEntry[] spawnEntries;
    private float[] intervals;

    public float spawnRange = 100f;

    [System.Serializable]
    public class SpawnEntry {
        public float spawnDelay;
        public float interval;
        public GameObject objectToSpawn;
    }

    private void Start() {
        intervals = new float[spawnEntries.Length];
        for (int i = 0; i < spawnEntries.Length; i++) {
            intervals[i] = spawnEntries[i].spawnDelay;
        }
    }

    private void Update() {
        for (int i = 0; i < intervals.Length; i++) {
            intervals[i] -= Time.deltaTime;

            if (intervals[i] <= 0) {
                intervals[i] = spawnEntries[i].interval;
                Instantiate(spawnEntries[i].objectToSpawn, Player.Instance.transform.position + new Vector3(
                        Random.Range(-spawnRange, spawnRange),
                        Random.Range(-spawnRange, spawnRange),
                        0),
                    Quaternion.identity);
            }
        }
    }
}
