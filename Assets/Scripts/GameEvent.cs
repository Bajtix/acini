using UnityEngine;

public abstract class GameEvent : ScriptableObject {
    public string title;

    public bool executed = false;

    public virtual void Execute() {
        executed = true;
    }
}