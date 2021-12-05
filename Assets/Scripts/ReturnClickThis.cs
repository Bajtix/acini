using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnClickThis : MonoBehaviour {
    private Controls c;
    private void Awake() {
        c = new Controls();
    }
    private void OnEnable() {
        c.Enable();
        c.Default.Return.performed += (_) => GetComponent<Button>().onClick.Invoke();
    }

    private void OnDisable() {
        c.Disable();
        c.Default.Return.performed -= (_) => GetComponent<Button>().onClick.Invoke();
    }
}
