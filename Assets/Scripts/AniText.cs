using ElRaccoone.Tweens;
using TMPro;
using UnityEngine;

public class AniText : MonoBehaviour {

    private TextMeshProUGUI textMeshPro;

    protected virtual void Awake() {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public virtual void Animate(string text) {
        textMeshPro.text = text;
    }


    public string GetText() {
        return textMeshPro.text;
    }

}
