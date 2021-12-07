using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GameScheduler : MonoBehaviour {

    #region Singleton 
    private static GameScheduler instance;
    public static GameScheduler Instance {
        get {
            if (instance == null) instance = GameObject.FindObjectOfType<GameScheduler>();
            return instance;
        }
    }
    #endregion
    [System.Serializable]
    public class MGameEvent {
        public GameEvent gameEvent;
        public float gameTime;
    }

    public MGameEvent[] list;

    public float gameTime;
    public int currentGoal;


    private void Start() {
        Sort();

        for (int i = 0; i < list.Length; i++) {
            list[i].gameEvent = Instantiate(list[i].gameEvent);
        }
    }

    public float GetProgress() {
        if (currentGoal == 0 || currentGoal >= list.Length) return 0;
        float t1 = list[currentGoal - 1].gameTime;
        float t2 = list[currentGoal].gameTime;

        return (gameTime - t1) / (t2 - t1);
    }

    public MGameEvent GetLastEvent() {
        if (currentGoal == 0 || currentGoal - 1 >= list.Length) return null;
        return list[currentGoal - 1];
    }

    public MGameEvent GetNextEvent() {
        if (currentGoal < 0 || currentGoal >= list.Length) return null;
        return list[currentGoal];
    }

    [Button("Sort")]
    private void Sort() {
        Array.Sort(list, (a, b) => Mathf.RoundToInt(a.gameTime * 100 - b.gameTime * 100));
    }

    private void Update() {
        gameTime += Time.deltaTime;

        foreach (var v in list) { // TODO: can possibly be simplified as the array is sorted
            if (v.gameEvent.executed == false && v.gameTime <= gameTime) {
                currentGoal++;
                v.gameEvent.Execute();

            }
        }
    }
}
