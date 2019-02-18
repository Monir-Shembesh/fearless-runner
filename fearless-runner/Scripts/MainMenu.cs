using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {


    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;      
    [SerializeField] private Text loadingPercentageText;   // code is good
    [SerializeField] private Text songName;



    public void startGame(string sceneName) {  // public function that is called when button is pressed. 
        StartCoroutine(LoadAsyn(sceneName));
    }


    public void accessFaceBook() {
        Application.OpenURL("https://www.facebook.com/MonirVlogs");
    }

    public void accessTwitter()         // normal link call
    {
        Application.OpenURL("https://twitter.com/aka_Zyzz");
    }

    public void accessYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCAst2da8uAZcWHBz1Af2f-g");
    }




    IEnumerator LoadAsyn(string sceneName)   // coroutine to make a loading screen then after screen is done we switch to new scene
    {
        AsyncOperation operationLoadingScene = SceneManager.LoadSceneAsync(sceneName);
        songName.enabled = false;
        loadingScreen.SetActive(true);
        while (!operationLoadingScene.isDone)
        {
            float progress = Mathf.Clamp01(operationLoadingScene.progress / 0.9f);
            loadingSlider.value = progress;
            loadingPercentageText.text = Mathf.FloorToInt(progress * 100f) + "%";
            yield return null;
        }
    }




}
