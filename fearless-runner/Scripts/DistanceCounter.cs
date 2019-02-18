using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceCounter : MonoBehaviour
{
    public static DistanceCounter instance = null;
    [SerializeField] private Text Distance;
    [SerializeField] private GameObject Player;  // just getting the game object for both text and player
    [SerializeField] private float PlusOrMinusNumber;   //use this value when the counter start with -number (-4) or + number (6) instead of 0
    public int meters;


    private int previousMeter = 0;
    private Vector3 startPoint;

    void Awake()
    {
        startPoint = transform.position;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // we have this in 2.0
        //EventManager.MeterUpdate += onMeterUpdate;

        // with 3.5 4.5
        EventManager.MeterUpdate = (meter) => {
            Distance.text = meter.ToString() + " M";
        };
    }

    //private void onMeterUpdate(int meter)
    //{
    //    Distance.text = meter.ToString() + " M";
    //}

    void FixedUpdate()
    {
        meters = Mathf.FloorToInt((PlusOrMinusNumber + Player.transform.position.x) - startPoint.x); // converting to int
        
        if(meters > previousMeter) // we update text only if meters value is different from previously calculated value and print it to UI
        {
            // we have to use this to check if meterupdate has valid listener
            if(EventManager.MeterUpdate != null)
            { 
                EventManager.MeterUpdate.Invoke(meters);
             }
            //// with 4.5, this will do the same
            //EventManager.MeterUpdate?.Invoke(meters);

            previousMeter = meters;
        }
        
    }





}
