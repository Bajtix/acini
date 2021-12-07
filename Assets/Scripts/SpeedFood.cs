using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedFood : Food {
    public float speedIncrease;

    public override void Eat() {
        Player.Instance.speed += speedIncrease;
        GameUI.Instance.AnnounceBooster("Speed", speedIncrease);
        base.Eat();
    }
}
