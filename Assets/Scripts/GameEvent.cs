using UnityEngine;

public abstract class GameEvent : ScriptableObject {
    public string title;
    public int pointReward;

    [HideInInspector] public bool executed = false;

    public virtual void Execute() {
        executed = true;
    }
}