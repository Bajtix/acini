using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoDeathMessage : MonoBehaviour {
    public TextMeshProUGUI text;

    public string[] messages;

    private void OnEnable() {
        string msg = messages[Random.Range(0, messages.Length)];
        text.text = $"{msg}<br><size=12>SCORE:{GameManager.instance?.score}<br>BEST:{GameManager.instance?.highscore}";
    }
}
