using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHirozontalMovement : MonoBehaviour {

	[SerializeField] private float movementSpeed;
	[SerializeField] private float speedMultiplier;
	[SerializeField] private float speedIncreaseMilestone;  // some variables to allocate speed and increase the camera movement speed after checkPoints
	[SerializeField] private float smoothingNumber;
 //   public float maxSpeed;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float speedMilestoneCount;



    void Start()
    {

        speedMilestoneCount = speedIncreaseMilestone;  // speed mile stone count will equal increase mile stone = 100
    }



    void FixedUpdate()
    {
        _startPosition = transform.position;
        _endPosition = new Vector3(transform.position.x + movementSpeed, 0, 0);
        transform.position = Vector3.Lerp(_startPosition, _endPosition, Time.deltaTime * (movementSpeed * smoothingNumber));
        IncreaseCameraSpeed();

    }


    private void IncreaseCameraSpeed()
    {    // code here is to increase camera speed after check point
        if (transform.position.x > speedMilestoneCount ) // && movementSpeed < maxSpeed
        {  // if camera x position > than check point
            speedMilestoneCount += speedIncreaseMilestone; // setting the new speedMileStoneCount so it can be reused in If condition
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; // here it is creating a new milestone
            movementSpeed = movementSpeed * speedMultiplier;// increase camera speed using our speed variable
        }

    }

    



}




