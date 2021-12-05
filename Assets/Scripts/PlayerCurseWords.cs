using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurseWords : MonoBehaviour {

    public string[] curses;
    public string Next() {
        return curses[Random.Range(0, curses.Length)];
    }
}
