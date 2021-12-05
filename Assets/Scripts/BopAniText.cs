using UnityEngine;
using ElRaccoone.Tweens;

public class BopAniText : AniText {
    public override void Animate(string text) {
        base.Animate(text);

        gameObject.TweenLocalScale(new Vector3(1.2f, 1.2f, 1.2f), 0.05f).SetOnComplete(() => {
            gameObject.TweenLocalScale(Vector3.one, 0.05f);
        });
    }
}
