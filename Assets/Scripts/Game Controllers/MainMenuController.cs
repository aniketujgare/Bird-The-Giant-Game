using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button musicBtn;
    [SerializeField] private Sprite[] musicIcon;
    // Start is called before the first frame update
    void Start()
    {
        CheckToPlayMusic();
    }
    void CheckToPlayMusic()
    {
        if (GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcon[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcon[0];
        }
    }
    public void StartGame ()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        //SceneManager.LoadScene("Gameplay");
        SceneFader.instance.LoadLevel("Gameplay");
    }
    public void HighScoreMenu()
    {
        SceneManager.LoadScene("HighScoreScene");
        //SceneFader.instance.LoadLevel("HighScoreScene");
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
        //SceneFader.instance.LoadLevel("OptionsMenu");
    }
    public void QuitGame ()
    {
        Application.Quit();
    }
    public void MusicButton()
    {
        if (GamePreferences.GetMusicState () == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcon[1];
        }
        else if (GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcon[0];
        }
    }
}
