using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AniText : MonoBehaviour
{
    public bool enableDissapear = false;
    private float dissappear = 0;
    public void Text(string text, float maxDuration = 1)
    {
        GetComponent<TextMeshProUGUI>().text = text;
        dissappear = maxDuration;
        LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.05f).setOnComplete(() => LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.05f));
    }

    private void Update()
    {
        dissappear -= Time.deltaTime;
        if (dissappear <= 0 && enableDissapear)
        {
            GetComponent<TextMeshProUGUI>().text = "";
        }
    }
}
