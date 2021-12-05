using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChadFood : Food
{
    public override void Eat()
    {
        Player.instance.Chad(10);
        base.Eat();

    }
}
