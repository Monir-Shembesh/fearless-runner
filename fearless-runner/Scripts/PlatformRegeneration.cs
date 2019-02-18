using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRegeneration : MonoBehaviour {

//	[SerializeField] private GameObject ceiling;
	[SerializeField] private GameObject backGround;
	[SerializeField] private GameObject cameraObject;
	[SerializeField] private float newPosistion;
    [SerializeField] private float extraRePositionValue;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		platformReposition ();

	}


	private void platformReposition(){

		if (cameraObject.transform.position.x > (backGround.transform.position.x) + extraRePositionValue) {
            backGround.transform.position += new Vector3 (newPosistion,0,0);
		}

	}
}
