using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public static SceneFader instance;
    [SerializeField] private GameObject fadePanel;

    [SerializeField] Animator fadeAnim;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut (string level)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        
        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(1f));
        SceneManager.LoadScene(level);
        fadeAnim.Play("FadeOut");

        yield return StartCoroutine(MyCoroutine.WaitForRealSeconds(0.7f));
        fadePanel.SetActive(false);
    }
}
