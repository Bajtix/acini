using UnityEngine.UI;
using UnityEngine;

public class GameUI : MonoBehaviour {

    #region Singleton 
    private static GameUI instance;
    public static GameUI Instance {
        get {
            if (instance == null) instance = GameObject.FindObjectOfType<GameUI>();
            return instance;
        }
    }
    #endregion

    public CanvasGroup deathPanel;
    public Slider hungerBar;
    public AniText scoreText;

    private float hungerTarget;

    public void SetHunger(float hunger) {
        hungerTarget = hunger;
    }

    public void BopHunger() {
        // make the progress bar go [  ] and than return to  []
    }

    public void Score(long score) {
        if (score.ToString("0000") != scoreText.GetText())
            scoreText.Text(score.ToString("0000"));
    }

    public void Die() {

    }

    private void Update() {
        //update hunger bar
        hungerBar.value = Mathf.Lerp(hungerBar.value, hungerTarget, Time.deltaTime * 10f); //update hunger preview
    }

}
