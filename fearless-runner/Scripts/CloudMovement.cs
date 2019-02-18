using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour {


    [SerializeField] private float movementSpeed;
    [SerializeField] private float outOfBoundriesPos;
    [SerializeField] private float yPosition;
    [SerializeField] private float zPosition;
    [SerializeField] private float newPosition;
    [SerializeField] private GameObject cloud;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ScreenMovement();


    }




    //Main Screen Movement --->

    private void ScreenMovement()
    {
        transform.position -= new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        if (cloud.transform.position.x < outOfBoundriesPos)
        {
            cloud.transform.position = new Vector3(newPosition, yPosition, zPosition);
        }
    }



    
}
