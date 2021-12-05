using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour {
    private Controls c;

    private void Awake() {
        c = new Controls();
    }

    private void OnEnable() {
        c.Enable();

        c.Default.Return.performed += (_) => LoadGame();
        c.Default.Escape.performed += (_) => Quit();
    }

    private void OnDisable() {
        c.Disable();
    }


    public void LoadGame() {
        GetComponent<Loader>().StartGame();
    }

    public void Quit() {
        Application.Quit();
    }
}
