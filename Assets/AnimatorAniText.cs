using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimatorAniText : AniText {
    private Animation anim;

    protected override void Awake() {
        base.Awake();
        anim = GetComponent<Animation>();
    }

    public override void Animate(string text) {
        base.Animate(text);
        anim.Play();
    }
}
