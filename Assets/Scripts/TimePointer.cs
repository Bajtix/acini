using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePointer : MonoBehaviour {
    #region Singleton 
    private static TimePointer instance;
    public static TimePointer Instance {
        get {
            if (instance == null) instance = GameObject.FindObjectOfType<TimePointer>();
            return instance;
        }
    }
    #endregion

    public float timer;
    public float nextTimeAchievement = 4;
    public long nextPoints = 2;
    public int achievementCount = 1;

    private void Update() {
        if (Player.instance.alive) {
            timer += Time.deltaTime;

            nextTimeAchievement -= Time.deltaTime;
        }
        if (nextTimeAchievement <= 0) {
            Player.instance.Score(nextPoints);
            GameUI.Instance.AnnouncePoints("Survival", nextPoints);

            nextPoints = (long)System.Math.Pow(2, achievementCount);
            achievementCount++;
            nextTimeAchievement = 2 * achievementCount;
            Player.instance.hungerSpeed += 0.005f;
        }
    }

}
