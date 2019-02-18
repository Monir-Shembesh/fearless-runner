using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    private bool tap;
    private bool swipeUp;
    private bool swipeDown;
    private bool swipeLeft;
    private bool swipeRight;
    private bool isDragging = false;
    private Vector2 startTouch;
    private Vector2 swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool Tap { get { return tap; } }
    public bool SwipeUP { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeLeft { get { return swipeLeft; } }


    private void Update()
    {
        tap = swipeDown = swipeUp = false;

        #region Standalone Inputs

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            tap = true;
            isDragging = false;
            Reset();
        }


        #endregion

        #region Mobile Inputs

        if (Input.touches.Length > 0)
        {

            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                tap = true;
                isDragging = false;
                Reset();
            }

        }

        #endregion

        //Calculate Distance

        swipeDelta = Vector2.zero;
        if (isDragging)
        {
            if (Input.touches.Length > 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //  Did we cross the deadZone?

        if (swipeDelta.magnitude > 30)
        {

            //Which Direction
            float y = swipeDelta.y;
            float x = swipeDelta.x;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //left or right
                if (x < 0)
                {
                    swipeLeft = true;
                }
                else
                {
                    swipeRight = true;
                }

            }
            else
            {
                //up or down
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                }


                Reset();
            }

        }
    }


    private void Reset() {
        startTouch = swipeDelta = Vector2.zero;
            isDragging = false;
    }

}
