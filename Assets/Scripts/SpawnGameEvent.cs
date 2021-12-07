using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event", menuName = "Game/Event/Enemy")]
public class SpawnGameEvent : GameEvent {
    public enum SpawnerModType {
        add, remove
    }

    public SpawnerModType type;

    [ShowIf("type", SpawnerModType.add)]
    [Label("Entries")]
    public List<SpawnerEntry> entries_a;

    [ShowIf("type", SpawnerModType.remove)]
    [Label("Entries")]
    public List<string> entries_r;

    public override void Execute() {
        if (type == SpawnerModType.add) {
            foreach (var v in entries_a) {
                Spawner.Instance.Add(v.name, v);
            }
        } else {
            foreach (var v in entries_r) {
                Spawner.Instance.Remove(v);
            }
        }

        base.Execute();
    }
}