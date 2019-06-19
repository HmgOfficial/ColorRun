using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource sfxSource;
    public AudioSource musicSource;
    public GameManager gameManager;
    //public GameObject musicSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*if (gameManager.music == true)
        {
            musicSource.mute = false;
        }
        else
        {
            musicSource.mute = true;
        }
        if (gameManager.sfx == true)
        {
            sfxSource.mute = false;
        }
        else
        {
            sfxSource.mute = true;
        }*/

    }
    public void PlayButtonSound()
    {
        sfxSource.Play();
    }
    public void PauseMusic()
    {
        musicSource.Pause();
    }
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }
}
