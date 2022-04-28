using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    public string currentLevel;

   

    void start()
    {

    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene(currentLevel);
		}
    }
    public void menuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
        print("Qick Button Was Clicked");
    }

}
