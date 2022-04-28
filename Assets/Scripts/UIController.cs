using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject helpPanel;
    public GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        helpPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void helpButton()
    {
        helpPanel.SetActive(true);
    }
    public void okButton()
    {
        helpPanel.SetActive(false);
    }
    public void creditsButton()
    {
        creditsPanel.SetActive(true);
    }
    public void returnButton()
    {
        creditsPanel.SetActive(false);
    }
    public void QuitButton()
    {
        Application.Quit();
        print("Quit Button was pressed.");
    }
}
