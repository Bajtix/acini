using ElRaccoone.Tweens;
using TMPro;
using UnityEngine;

public class AniText : MonoBehaviour {
    public bool enableDissapear = false;
    private float dissappear = 0;

    private TextMeshProUGUI textMeshPro;

    private void Start() {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    public void Text(string text, float maxDuration = 1) {
        textMeshPro.text = text;
        dissappear = maxDuration;

        gameObject.TweenLocalScale(new Vector3(1.2f, 1.2f, 1.2f), 0.05f).SetOnComplete(() => {
            gameObject.TweenLocalScale(Vector3.one, 0.05f);
        });
    }

    public string GetText() {
        return textMeshPro.text;
    }

    private void Update() {
        dissappear -= Time.deltaTime;
        if (dissappear <= 0 && enableDissapear) {
            GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
