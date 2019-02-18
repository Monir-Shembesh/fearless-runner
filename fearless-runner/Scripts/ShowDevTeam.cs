using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDevTeam : MonoBehaviour {

    [SerializeField] GameObject devTeam;
    [SerializeField] GameObject playButton;



    public void ShowDevTeamOnOff() {

        if (devTeam.activeInHierarchy)
        {
            playButton.SetActive(true);
            devTeam.SetActive(false);
        }
        else {
            playButton.SetActive(false);
            devTeam.SetActive(true);
        }

    }

}
