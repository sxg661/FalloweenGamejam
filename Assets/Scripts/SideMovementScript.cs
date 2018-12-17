using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovementScript : MonoBehaviour {

    public static float speed = 6f;

    public static float myX;
    public static float myY;

    bool stationary = true;

    Animator anim;

    public enum direction
    {
        LEFT, RIGHT
    }

    public direction myDirection;

    Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        myDirection = direction.RIGHT;
        myX = transform.position[0];
        myY = transform.position[1];
        speed = 6f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float xInput = Input.GetAxis("Horizontal");
        float xMove = 0f;

        myX = transform.position[0];
        myY = transform.position[1];


        Vector3 camEdgePos = Camera.main.ScreenToWorldPoint(Vector3.zero);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(myDirection == direction.LEFT)
            {
                anim.SetTrigger("right");
            }
            
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (myDirection == direction.RIGHT)
            {
                anim.SetTrigger("left");
            }
        }

        if (xInput > 0)
        {
            xMove = speed;
            myDirection = direction.RIGHT;
            stationary = false;

            
        }
        else if ((LevelRenderer.getTile( camEdgePos[0] ) >= LevelRenderer.getTile(transform.position[0]) )  )
        {
            xMove = 0;
        }
        else if(xInput < 0)
        {

        

            xMove = -speed;
            myDirection = direction.LEFT;
            stationary = false;


        }
        

        myBody.velocity = new Vector2(xMove, myBody.velocity[1]);






    }
}
