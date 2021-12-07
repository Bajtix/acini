using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {
    #region Singleton 
    private static Spawner instance;
    public static Spawner Instance {
        get {
            if (instance == null) instance = GameObject.FindObjectOfType<Spawner>();
            return instance;
        }
    }
    #endregion


    private Dictionary<string, SpawnerEntry> spawnables;

    public float spawnRadius = 100f;
    public float scale = 2f;

    private void Awake() {
        spawnables = new Dictionary<string, SpawnerEntry>();
    }

    public void Add(string n, SpawnerEntry e) {
        Debug.Log($"New spawnable: {n}");
        if (spawnables.ContainsKey(n))
            spawnables.Remove(n);
        spawnables.Add(n, e);
    }

    public void Remove(string n) {
        Debug.Log($"Remove spawnable: {n}");
        if (spawnables.ContainsKey(n))
            spawnables.Remove(n);
    }

    private void Update() {
        foreach (var v in spawnables.Values) {
            if (v.ShouldSpawn(Time.deltaTime * scale)) {
                Instantiate(v.gameObject, GetRandomPosition(), Quaternion.identity);
            }
        }
    }

    private Vector2 GetRandomPosition() {
        return new Vector2(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius));
    }
}