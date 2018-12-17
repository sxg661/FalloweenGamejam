using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

    public void quit()
    {
        Application.Quit();
    }

    public void startLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void endScreen()
    {
        SceneManager.LoadScene("EndScreen");
    }

    public void startScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }


}
