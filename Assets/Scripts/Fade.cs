using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour
{

    public static Fade our;

    private void Start()
    {
        our = this;
        GetComponent<CanvasGroup>().alpha = 1;
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 0, 0.2f).setOnComplete(() => gameObject.SetActive(false));
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        GetComponent<CanvasGroup>().alpha = 0;
        LeanTween.alphaCanvas(GetComponent<CanvasGroup>(), 1, 0.2f);
    }
}
