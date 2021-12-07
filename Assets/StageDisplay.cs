using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageDisplay : MonoBehaviour {
    public AniText text;
    public UnityEngine.UI.Slider bar;

    private void Update() {
        bar.value = GameScheduler.Instance.GetProgress();
        text.Animate(GameScheduler.Instance.GetLastEvent()?.gameEvent.title);
    }
}
