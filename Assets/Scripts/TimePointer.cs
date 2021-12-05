using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePointer : MonoBehaviour
{
    public static TimePointer instance;
    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(instance);

        instance = this;
    }

    public float timer;
    public float nextTimeAchievement = 4;
    public long nextPoints = 2;
    public int achievementCount = 1;

    private void Update()
    {
        if (Player.instance.alive)
        {
            timer += Time.deltaTime;

            nextTimeAchievement -= Time.deltaTime;
        }
        if (nextTimeAchievement <= 0)
        {
            Player.instance.Score(nextPoints);
            Player.instance.status.Text($"Survival expert! <align=\"right\"><size=22>{nextPoints}x");
            nextPoints = (long)System.Math.Pow(2, achievementCount);
            achievementCount++;
            nextTimeAchievement = 2 * achievementCount;
            Player.instance.hungerSpeed += 0.005f;
        }
    }

}
