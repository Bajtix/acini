using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    public Player player;
    public Controls playerControls;


    private void Awake() {
        playerControls = new Controls();
    }

    private void OnEnable() {
        playerControls.Enable();
        playerControls.Default.Up.performed += (_) => player.SetInput(Vector2.up);
        playerControls.Default.Down.performed += (_) => player.SetInput(Vector2.down);
        playerControls.Default.Right.performed += (_) => player.SetInput(Vector2.right);
        playerControls.Default.Left.performed += (_) => player.SetInput(Vector2.left);

    }

    private void OnDisable() {
        playerControls.Disable();
    }


}
