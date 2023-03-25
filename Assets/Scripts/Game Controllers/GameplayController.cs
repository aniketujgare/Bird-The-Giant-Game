using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    [SerializeField] private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;
    [SerializeField] GameObject pausePanel, gameOverPanel;
    [SerializeField] private GameObject readyButton;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("GameInitialized"))
        {
            readyButton.transform.GetChild(1).gameObject.SetActive(false);
            readyButton.transform.GetChild(2).gameObject.SetActive(false);
        }
        
       Time.timeScale = 0f;
    }
    public void GameOverShowPanel(int fialScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = fialScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");
    }
    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestart());
    }
    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        //SceneManager.LoadScene("Gameplay");
        SceneFader.instance.LoadLevel("Gameplay");
    }
    public void SetScore(int Score)
    {
        scoreText.text = "x" + Score + " ";
    }
    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }
    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }
    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }
    public void QuitGame()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
        SceneFader.instance.LoadLevel("MainMenu");

    }
    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.gameObject.SetActive(false);
    }
}
