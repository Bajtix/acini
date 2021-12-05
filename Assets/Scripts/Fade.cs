using ElRaccoone.Tweens;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour {
    public static Fade our; // simplified not-really singleton thing

    public float fadeDuration = 0.2f;
    private CanvasGroup cg;

    private void Start() {
        our = this;
        cg = GetComponent<CanvasGroup>();

        FadeOut();
    }

    public void FadeIn() {
        gameObject.SetActive(true);

        cg.alpha = 0;
        cg.TweenCanvasGroupAlpha(1, fadeDuration);
    }

    public void FadeOut() {
        gameObject.SetActive(true);

        cg.alpha = 1;
        cg.TweenCanvasGroupAlpha(0, fadeDuration).SetOnComplete(() => gameObject.SetActive(false));
    }
}
