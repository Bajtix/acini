using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChadFood : Food {
    public override void Eat() {
        Player.Instance.Chad(10);
        GameUI.Instance.AnnounceBooster("GIGHACHAD", 10);
        base.Eat();
    }
}
