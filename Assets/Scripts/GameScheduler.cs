using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

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
        public float duration;
        [ReadOnly]
        public float gameTime;
    }

    public MGameEvent[] list;

    public float gameTime;
    public int currentGoal;


    private float CalculateGT(int i) {
        float r = 0;
        for (int j = 0; j < i; j++) {
            r += list[j].duration;
        }

        return r;
    }

    private void Start() {
        Sort();

        for (int i = 0; i < list.Length; i++) {
            list[i].gameEvent = Instantiate(list[i].gameEvent); // clone them so they are runtime only (for editor safety/convinience)
        }
    }

    public float GetProgress() {
        if (currentGoal == 0 || currentGoal >= list.Length) return 0;
        float t1 = list[currentGoal - 1].gameTime;
        float t2 = list[currentGoal].duration;

        return (gameTime - t1) / t2;
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

        for (int i = 0; i < list.Length; i++) {
            list[i].gameTime = CalculateGT(i);
        }
    }

    private void PointReward() {
        if (currentGoal < 0 || currentGoal >= list.Length) return;
        int pts = list[currentGoal].gameEvent.pointReward;
        Player.Instance.Score(pts);
        GameUI.Instance.AnnouncePoints("Survival", pts);
    }

    private void Update() {
        if (Player.Instance.alive)
            gameTime += Time.deltaTime;

        foreach (var v in list) { // TODO: can possibly be simplified as the array is sorted
            if (v.gameEvent.executed == false && v.gameTime <= gameTime) {
                PointReward();

                currentGoal++;
                v.gameEvent.Execute();


            }
        }
    }
}
