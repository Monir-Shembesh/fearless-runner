using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private Text loadingPercentageText;

    GameObject Player;
    AudioSource PlayerMusic;
    GameObject musicManager;
    AudioSource gameplayMusic;


    private void Awake()
    {
        Player = GameObject.Find("Yan");
        PlayerMusic = Player.GetComponent<AudioSource>();
        musicManager = GameObject.Find("musicManagerGamePlay");
        gameplayMusic = musicManager.GetComponent<AudioSource>();
    }

    public void GoHomelOADING(string sceneName)
    {
        StartCoroutine(LoadAsyn(sceneName));
        pauseFunction.instance.trunPauseOff();
    }

    public void rateMe()
    {
        UniRate.Instance.OpenRatePage();
    }

    public void PauseMenuOnOff()
    {
        if (mainCanvas.activeInHierarchy)
        {
            PlayerMusic.Play();
            gameplayMusic.Play();
            mainCanvas.SetActive(false);
            pauseButton.SetActive(true);
        }
        else
        {
            PlayerMusic.Stop();
            gameplayMusic.Pause();
            mainCanvas.SetActive(true);
            pauseButton.SetActive(false);
        }
    }


    public void restartRound(string SceneName)
    {
        pauseFunction.instance.trunPauseOff();
        SceneManager.LoadScene(SceneName);
    }



    IEnumerator LoadAsyn(string sceneName)
    {
        AsyncOperation operationLoadingScene = SceneManager.LoadSceneAsync(sceneName);
     //   songName.enabled = false;
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
