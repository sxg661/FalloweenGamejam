using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour {

    public GameObject mainCamera;
    Camera myCam;
    SideMovementScript movement;
    float standardY;

	// Use this for initialization
	void Start () {
        myCam = mainCamera.GetComponent<Camera>();
        movement = GetComponent<SideMovementScript>();
        myCam.transform.position = new Vector3(transform.position[0], myCam.transform.position[1], -10);
        standardY = myCam.transform.position[1];
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position[1] >= standardY)
        {
            myCam.transform.position = new Vector3(myCam.transform.position[0], transform.position[1], -10);
        }

        if (! (movement.myDirection == SideMovementScript.direction.RIGHT) )
        {
            return;
        }

        if(transform.position[0] >= myCam.transform.position[0])
        {
            myCam.transform.position = new Vector3(transform.position[0], myCam.transform.position[1], -10);
        }

        




    }
}
