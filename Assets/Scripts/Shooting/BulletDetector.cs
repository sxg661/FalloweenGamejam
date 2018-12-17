using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletDetector : MonoBehaviour {

    public int lives;
    public string bulletName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == bulletName)
        {
            lives--;
        }

        if (lives == 0)
        {
            Debug.Log(col.gameObject.name);
            if (gameObject.name == "EvilDude(Clone)")
            {
                CandyDetector.myCandy += 10;
                Destroy(gameObject);
            }
            if (gameObject.name == "MrsPumpkinPatch"){
                SceneManager.LoadScene("EndScreen");
            }
            
        }

    }
}
