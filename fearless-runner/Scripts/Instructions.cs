using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {


    [SerializeField] GameObject instructionsScreen;
    [SerializeField] AudioSource playerFootSteps;
    [SerializeField] Swipe swipeGestures;





    void Start()
    {
        if (PlayerPrefs.GetInt("instructionsValue", 0) == 0)
        {
            playerFootSteps.Stop();
            pauseFunction.instance.trunPauseOn();
            instructionsScreen.SetActive(true);
            PlayerPrefs.SetInt("instructionsValue", 1);
        }
    }





    public void StartPlaying() {
        pauseFunction.instance.trunPauseOff();
        playerFootSteps.Play();
        instructionsScreen.SetActive(false);
        

    }
}
