using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySfx : MonoBehaviour {

    // Use this for initialization
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource mainMenuSong;
    AudioSource Sfx;



    private void Start()
    {
        Sfx = GetComponent<AudioSource>();

    }

    public void playLoadedSxf()
    {
        mainMenuSong.Stop();
        Sfx.PlayOneShot(clip);
    }


}
