using UnityEngine.SceneManagement;
using UnityEngine;
using ElRaccoone.Tweens;

public class GameManager : MonoBehaviour {
    #region Singleton 

    public static GameManager instance;

    #endregion

    public long score, highscore;
    public string username;


    public void Score(long result) {
        score = result;
        if (score > highscore) {
            highscore = score;
        }
        if (Application.platform != RuntimePlatform.WebGLPlayer)
            PlayerPrefs.SetString("hs", highscore.ToString());
    }

    private void Awake() {
        instance = this;
        if (Application.platform != RuntimePlatform.WebGLPlayer) {
            string s = PlayerPrefs.GetString("hs");
            if (!string.IsNullOrEmpty(s))
                highscore = long.Parse(s);
        }
    }

    public void LoadGame() {
        Fade.our.FadeIn();
        gameObject.DelayedInvoke(0.2f, () => SceneManager.LoadScene(1));
    }
}
