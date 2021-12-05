using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public TMPro.TMP_InputField inputField;
    public void StartGame()
    {
        //GameManager.instance.username = inputField.text;
        Time.timeScale = 1;
        GameManager.instance.LoadGame();
    }

}
