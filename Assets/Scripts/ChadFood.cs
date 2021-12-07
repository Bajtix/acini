using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChadFood : Food {
    public float chadTime = 8f;
    public override void Eat() {
        Player.Instance.Chad(chadTime);
        GameUI.Instance.AnnounceBooster("GIGHACHAD", chadTime);
        base.Eat();
    }
}
