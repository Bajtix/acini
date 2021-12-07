using UnityEngine;

[System.Serializable]
public class SpawnerEntry {
    public string name;
    public GameObject gameObject;
    public Vector2 interval;
    [HideInInspector] public float next = float.NegativeInfinity;

    public void NextInterval() {
        next = Random.Range(interval.x, interval.y);
    }

    public bool ShouldSpawn(float deltaTime) {
        if (next == float.NegativeInfinity) NextInterval(); // first time only

        next -= deltaTime;

        if (next <= 0) {
            NextInterval();
            return true;
        }

        return false;
    }

}