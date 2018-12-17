using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpingScript : MonoBehaviour {

    public static float jumpSpeed = 9f; 

    public bool jumping = false;
    public bool doubleJump = false;
    public bool upButtonDown = false;
    public bool upButtonLifted = true;

    Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        jumpSpeed = 9f;
        rigidBody = GetComponent<Rigidbody2D>();
        upButtonDown = false;
        upButtonLifted = true;
        Debug.Log("Name : " + SceneManager.GetActiveScene().name);
}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (upButtonLifted)
            {
                upButtonDown = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            upButtonLifted = true;
        }

        if (!(jumping && doubleJump) && upButtonDown)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity[0], jumpSpeed);

            if (!jumping)
            {
                jumping = true;
            }
            else
            {
                doubleJump = true;
            }

            upButtonDown = false;
            upButtonLifted = false;
        }

        if(jumping || doubleJump)
        {
            if(rigidBody.velocity[1] == 0)
            {
                jumping = false;
                doubleJump = false;
                upButtonDown = false;
                upButtonLifted = true;

}
        }
		
	}
}
