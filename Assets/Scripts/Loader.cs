using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

    public void StartGame() {
        Time.timeScale = 1;
        GameManager.instance.LoadGame();
    }

    public void MainMenu() {
        Time.timeScale = 1;
        GameManager.instance.LoadMenu();
    }

}
