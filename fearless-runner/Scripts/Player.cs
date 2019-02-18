using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField] private float jumpForce;
	[SerializeField] private float fallMultiplier;
    [SerializeField] private AudioSource footSteps;

    //[SerializeField] private float lowJumpMultiplier;





    private bool onGround = true;

    [SerializeField] Swipe swipeGestures;
	Rigidbody2D boxerPlayer;
	Animator anim;




	// Use this for initialization
	void Start () {
	
		//Getting the rigidbody for main Player
		boxerPlayer = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}



	// Update is called once per frame
	void Update () {

		Jump ();
	}


	private void Jump(){


		if (swipeGestures.SwipeUP && onGround) {
            boxerPlayer.velocity += Vector2.up * jumpForce;
            footSteps.Pause();
            anim.SetTrigger ("Yan_Jumping");
        }

        if (boxerPlayer.velocity.y < 0) {
			boxerPlayer.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime ;
		}

//		else if (boxerPlayer.velocity.y > 0 && !Input.GetMouseButton (0)){
//			boxerPlayer.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; // holding will make him jump higher
//		}


		//if ( swipeGestures.SwipeDown && onGround)
		//{
		//	Debug.Log ("sliding animation");
		//	//anim.SetTrigger ("slideOnGround");

		//}
        
        if ( swipeGestures.SwipeDown && !onGround){
			boxerPlayer.velocity += Vector2.down * jumpForce;
            anim.SetTrigger ("Yan_falling");


        }

    }

	void OnCollisionEnter2D(Collision2D collision){
		if ( collision.gameObject.tag == "Floor")
		{
            if (!footSteps.isPlaying)
            {
                footSteps.Play();
            }
            onGround = true;
		}
	}
     
	void OnCollisionExit2D (Collision2D collision){
		if ( collision.gameObject.tag == "Floor")
		{
            onGround = false;
		}
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }

}
