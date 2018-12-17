using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyScript : MonoBehaviour {

    float speed = 4f;
    public bool onGround;
    bool noCols;
    bool right;
    public float xspeed = 15f;
    public float yspeed = 2f;
    int n = 0;

    //Animator anim;

    public GameObject bullet;

    Rigidbody2D rigbody;

	// Use this for initialization
	void Start () {
        rigbody = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        noCols = true;
        right = true;
	}

   
	// Update is called once per frame
	void Update () {
   
        if( n % 100 == 0 && Mathf.Abs(SideMovementScript.myY - transform.position[1]) < 2)
        {
            if(Mathf.Abs(SideMovementScript.myX - transform.position[0]) < 10)
            {
                Debug.Log("detected");
                float offset = 0.5f;
                float xVel = xspeed;
                float yVel = yspeed;

                
                if (SideMovementScript.myX < transform.position[0])
                {
                    if (right)
                    {
                        //anim.SetTrigger("turn");
                        right = true;
                    }
                    offset = -offset;
                    xVel = -xVel;
                    yVel = -yVel;
                }
                else if (!right)
                {
                    //anim.SetTrigger("turn");
                    right = false;
                }

                GameObject projectile =
                     Instantiate(bullet, new Vector3(transform.position[0] + offset, transform.position[1], 0), Quaternion.identity);

                Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
                rb2d.velocity = new Vector2(xVel, yVel);
            }
        }
        n++;
        

    }

}
