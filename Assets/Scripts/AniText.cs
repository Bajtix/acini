using ElRaccoone.Tweens;
using TMPro;
using UnityEngine;

public class AniText : MonoBehaviour {

    private TextMeshProUGUI textMeshPro;

    public bool isText = true;

    protected virtual void Awake() {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    protected bool IsNew(string s) {
        return !isText || s != textMeshPro.text;
    }

    public virtual void Animate(string text) {
        if (isText)
            textMeshPro.text = text;
    }


    public string GetText() {
        return textMeshPro.text;
    }

}
