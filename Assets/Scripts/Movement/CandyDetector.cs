using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDetector : MonoBehaviour {

    public static int myCandy = 0;
    bool full = false;
    bool halfFull = false;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        myCandy = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (myCandy > 200 && full == false)
        {
            anim.SetTrigger("full");
            JumpingScript.jumpSpeed = 7f;
            SideMovementScript.speed = 4f;
            full = true;
        }
        else if (myCandy > 100 && halfFull == false)
        {
            JumpingScript.jumpSpeed = 8f;
            SideMovementScript.speed = 5f;
            anim.SetTrigger("halfFull");
            halfFull = true;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Candy")
        {
            myCandy += 1;
        }

    }
}
