using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTextController : MonoBehaviour {

    public GameObject mrsPumpkin;
    Text lives;
    BulletDetector bulletDetect;

    // Use this for initialization
    void Start () {
        lives = GetComponent<Text>();
        bulletDetect = mrsPumpkin.GetComponent<BulletDetector>();
	}
	
	// Update is called once per frame
	void Update () {
        lives.text = "Lives : " + bulletDetect.lives;
	}
}
