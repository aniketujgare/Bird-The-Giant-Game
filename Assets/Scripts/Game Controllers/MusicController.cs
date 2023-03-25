using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{


    public static MusicController instance;
    private AudioSource audiosource;

    private void Awake()
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

        audiosource = GetComponent<AudioSource>();
        
    }

    public void PlayMusic(bool play)
    {
        
        if (play)
        {
            if (!audiosource.isPlaying)
            {
                audiosource.Play();
            }
            
        }
        else
        {

            if (audiosource.isPlaying)
            {
                audiosource.Stop();
            }
        }
    }

}
