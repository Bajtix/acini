using ElRaccoone.Tweens;
using UnityEngine;
using System;

#pragma warning disable CS0618 // disable obsolete. I don't have another library, but I'm keeping my own fork of unity-tweens for now.
public static class Utils {
    public static void DelayedInvoke(this GameObject c, float delay, Action action) {
        c.TweenDelayedInvoke(delay, action);
    }
}