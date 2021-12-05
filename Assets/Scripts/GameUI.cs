using UnityEngine.UI;
using UnityEngine;
using ElRaccoone.Tweens;
using TMPro;

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
    public AniText scoreAnnouncer;

    private float hungerTarget;
    private Controls c;

    private void Awake() {
        c = new Controls();
    }


    public void SetHunger(float hunger) {
        hungerTarget = hunger;
    }

    public void BopHunger() {
        // make the progress bar go [  ] and than return to  []
        hungerBar.GetComponent<AniText>().Animate("");
        hungerBar.value = hungerTarget;
    }

    public void Score(long score) {
        if (score.ToString("0000") != scoreText.GetText())
            scoreText.Animate(score.ToString("0000"));
    }

    public void Die() {
        deathPanel.gameObject.SetActive(true);
        deathPanel.TweenCanvasGroupAlpha(1, 0.04f).SetFrom(0);
        c.Enable();
        c.Default.Return.performed += (_) => ReplayGame();
        c.Default.Escape.performed += (_) => MainMenu();
    }

    private void OnDisable() {
        c.Disable();
    }

    public void AnnouncePoints(string name, long bonus) {
        Announce($"{name}<br><align=\"right\"><size=22>{bonus}x");
    }

    public void AnnounceBooster(string name, float bonus) {
        Announce($"{name}<br><align=\"right\"><size=22>{(bonus > 0 ? "+" : "-")}{bonus}");
    }

    public void Announce(string text) {
        var txt = Instantiate(scoreAnnouncer.gameObject, transform).GetComponent<AniText>();
        txt.Animate(text);
        Destroy(txt, 5f);
    }

    private void Update() {
        //update hunger bar
        hungerBar.value = Mathf.Lerp(hungerBar.value, hungerTarget, Time.deltaTime * 10f); //update hunger preview
    }

    public void ReplayGame() { // TODO: scene loading needs a rework
        GetComponent<Loader>().StartGame();
    }

    public void MainMenu() {
        GetComponent<Loader>().MainMenu();
    }


}
