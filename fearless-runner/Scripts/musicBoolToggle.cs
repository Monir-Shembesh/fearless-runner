using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicBoolToggle : MonoBehaviour {

    [SerializeField] private GameObject musicToggle;
    [SerializeField] private GameObject DevTeam;



    public void toggleOnOff() {
        if (musicToggle.activeInHierarchy)
        {
            DevTeam.SetActive(false);
            musicToggle.SetActive(false);
        }
        else {
            DevTeam.SetActive(true);
            musicToggle.SetActive(true);
        }
    }



}
