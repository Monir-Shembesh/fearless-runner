using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour {


    public static Music instance = null;
	[SerializeField] private AudioClip[] MusicArray;
	[SerializeField] private string[] musicNames;
	[SerializeField] private Text SongnameObject;
	public AudioSource mainMenuSong;
	private int songNumber;
	private float sec = 4f;


    void Awake()
    {


        // Making Sure there is a singleton of game maker
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }





    }

    // Use this for initialization
    void Start ()
    {
        ChoosingMusic ();
        PlaySong ();
	}
	
	public void ChoosingMusic(){


		//if (songNumber == MusicArray.Length - 1) {
			songNumber = Random.Range(0, MusicArray.Length);
        if (mainMenuSong != null)
        {
            mainMenuSong.Stop();
        }
        PlaySong ();
			StartCoroutine (LateCall ());
		//} else {
		//	songNumber++;
		//	mainMenuSong.Stop ();
		//	PlaySong ();
		//	StartCoroutine (LateCall ());
		//}
			

	}

	private void PlaySong(){
		mainMenuSong = GetComponent<AudioSource>();
        int newSongNumber = Mathf.FloorToInt(songNumber);
        mainMenuSong.clip = MusicArray [newSongNumber];
		mainMenuSong.Play();
		StartCoroutine (LateCall ());
	}




	IEnumerator LateCall()
	{
		SongnameObject.text = musicNames [songNumber];
		SongnameObject.CrossFadeAlpha(1.0f, 1f, false);

		yield return new WaitForSeconds(sec);

		SongnameObject.CrossFadeAlpha(0f, 1f, false);

	}

    


}
