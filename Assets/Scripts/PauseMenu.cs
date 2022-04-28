using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject messageBox;
    public GameObject helpPanel;
    bool pause;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        messageBox.SetActive(true);
        helpPanel.SetActive(false);
        //continueButton.onClick.AddListener(ContinueButton);
        pause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause == false)
            {
                AudioListener.pause = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
                messageBox.SetActive(true);
                pause = true;
            }
            else if (pause == true)
            {
                AudioListener.pause = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                pauseMenu.SetActive(false);
                messageBox.SetActive(false);
                pause = false;
            }
        }
    }

    //public void ContinueButton()
    //{
    //pauseMenu.SetActive(false);
    //messageBox.SetActive(false);
    //}
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MainmenuButton()
    {
        SceneManager.LoadScene("Main Menu");
        AudioListener.pause = false;
        Time.timeScale = 1;
    }
    public void helpButton()
    {
        helpPanel.SetActive(true);
    }
    public void okButton()
    {
        helpPanel.SetActive(false);
    }
    public void continueButton()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        messageBox.SetActive(false);
        pause = false;
    }
}
