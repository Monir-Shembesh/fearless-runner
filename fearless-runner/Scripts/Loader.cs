using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {


	[SerializeField] private GameObject gameManger;
    [SerializeField] private GameObject LeaderBoardManager;


    void Awake(){
	
		if (GameManager.instance == null) {
			Instantiate (gameManger);
		} else if (GameManager.instance != null) {
			Destroy (gameManger);
		}
	
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
