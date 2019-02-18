using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallex : MonoBehaviour {


	[SerializeField] private Transform[] parallexObjects; // array of objects to apply parallex on
	[SerializeField] private float EffectStrenght = 1f;  // strength of the effect

	[SerializeField] private Transform cam;  // to get the cam position
	private Vector3 previousCamPosition;  // getting previous position for copmarison
	private float[] parallexScales; 




	// Use this for initialization
	void Start () {
		previousCamPosition = cam.position; // setting up cam pos
		parallexScales = new float[parallexObjects.Length]; // array of floats that contains the objects array lengh so if we have 3 or 4 obj. could be Int not float
		for (int i = 0; i < parallexObjects.Length; i++) {
			parallexScales [i] = parallexObjects [i].position.z * -1; // I think this gets you the z position. I forgot why minus 1 but yh array of z positions
		} 
	}



	// Update is called once per frame
	void FixedUpdate () {
		parallexEffectFunction ();  // calling the function lets change it to fix update
	}


	private void parallexEffectFunction(){
		for (int i = 0; i < parallexObjects.Length; i++) {  // looping
			float parallex = (previousCamPosition.x - cam.position.x) * parallexScales [i]; // deviding prev cam x with current cam x 
			float targetPosX = parallexObjects [i].position.x + parallex; // start of parallex effect 
			Vector3 finalTargetPos = new Vector3 (targetPosX, parallexObjects [i].position.y, parallexObjects [i].position.z); // move the object using all x values that i collected
			parallexObjects[i].position = Vector3.Lerp (parallexObjects[i].position, finalTargetPos, EffectStrenght * Time.deltaTime); // .lerp for smooth trans
		}

		previousCamPosition = cam.position; // setting new cam pos for comparision
	}
}
