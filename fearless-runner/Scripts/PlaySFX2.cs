using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX2 : MonoBehaviour
{

    // Use this for initialization
    [SerializeField] private AudioClip clip2;
    AudioSource Sfx2;



    private void Start()
    {
        Sfx2 = GetComponent<AudioSource>();

    }

    public void playLoadedSxf()
    {
        Sfx2.PlayOneShot(clip2);
    }


}
