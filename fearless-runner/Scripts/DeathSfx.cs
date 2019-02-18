using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSfx : MonoBehaviour {


    // Use this for initialization
    [SerializeField] private AudioClip DeathClipBarrel1;
    [SerializeField] private AudioClip DeathClipBlade2;

    public AudioSource Sfx;


    GameObject musicManager;
    AudioSource gameplayMusic;

    private void Awake()
    {
        Sfx.Play();
        musicManager = GameObject.Find("musicManagerGamePlay");
        gameplayMusic = musicManager.GetComponent<AudioSource>();
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Barrel")
        {
            Sfx.Stop();
            gameplayMusic.Stop();
            Sfx.PlayOneShot(DeathClipBarrel1, 1);
        }

        if (collision.gameObject.tag == "Blade")
        {
            Sfx.Stop();
            gameplayMusic.Stop();
            Sfx.PlayOneShot(DeathClipBlade2, 1);
        }

    }


}
