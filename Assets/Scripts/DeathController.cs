//////////////////////////////////////////////////////
// Assignment/Lab/Project: Project 3
//Name: Charles Wagner
//Section: 2020SP.SGD.212.4144
//Instructor: Aisha Eskandari
// Date: 4/22/2020
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public string sceneName;

    public void QuitButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(sceneName);
    }
}
