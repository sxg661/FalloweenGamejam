using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {

    public GameObject prefabs;
    Prefabs myPrefabs;
    bool friendly = true;
    GameObject myProjectile;
    float xspeed = 15f;
    float yspeed = 3f;
    SideMovementScript movement;

    void makeEnemy()
    {
        friendly = false;
    }

	// Use this for initialization
	void Start () {
        myPrefabs = prefabs.GetComponent<Prefabs>();
        myProjectile = myPrefabs.friendlyProjectile;
        movement = GetComponent<SideMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float offset = 0.25f;
            float xVel = xspeed;
            float yVel = yspeed;

            if(movement.myDirection == SideMovementScript.direction.LEFT)
            {
                offset = -offset;
                xVel = -xVel;
                yVel = -yVel;
            }



            GameObject projectile = 
                Instantiate(myProjectile, new Vector3(transform.position[0] + offset, transform.position[1], 0), Quaternion.identity);

            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector2(xVel, yVel);

        }
	}
}
