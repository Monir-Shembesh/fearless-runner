using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using VoxelBusters.NativePlugins;


public class death : MonoBehaviour {

    public static death instance = null;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private Text distanceToBeHidden;
    [SerializeField] public Text distanceToBeDisplayed;
    [SerializeField] private GameObject deathCanvas;
    [SerializeField] private Text highScoreText;

    GameObject musicManager;
    AudioSource gameplayMusic;



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



        musicManager = GameObject.Find("musicManagerGamePlay");
        gameplayMusic = musicManager.GetComponent<AudioSource>();


    }

  

    public void displayingDeathCanvas()
    {
        gameplayMusic.Stop();
        pauseButton.SetActive(false);
        pauseFunction.instance.trunPauseOn();
        distanceToBeHidden.enabled = false;

        if (DistanceCounter.instance.meters > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", DistanceCounter.instance.meters);



            //Social.ReportScore(DistanceCounter.instance.meters, "CgkI0Ob67vQdEAIQAQ", (bool success) => {
            //    if (success)
            //    {
            //        Debug.Log("score posted" + DistanceCounter.instance.meters);
            //    }
            //    else
            //    {
            //        Debug.Log("score post failed");
            //    }
            //});



            //not using this on android
            NPBinding.GameServices.ReportScoreWithGlobalID("globalId", DistanceCounter.instance.meters, (bool _success, string _error) =>
            {
                if (_success)
                {
                    Debug.Log(string.Format("Request to report score to leaderboard with GID= {0} finished successfully.", "globalId"));
                    Debug.Log(string.Format("New score= {0}.", DistanceCounter.instance.meters));
                }
                else
                {
                    Debug.Log(string.Format("Request to report score to leaderboard with GID= {0} failed.", "globalId"));
                    Debug.Log(string.Format("Error= {0}.", _error));
                }
            });



        }


        distanceToBeDisplayed.text = distanceToBeHidden.text;
        highScoreText.text = "Best " + PlayerPrefs.GetInt("highScore").ToString() + " M";
        deathCanvas.SetActive(true);
        UniRate.Instance.LogEvent(true);

        

    }

}
