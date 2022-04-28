using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    [Header("Buttons")]
    [SerializeField] private Button quitButton;
    [SerializeField] private Button startButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button closeButton1;
    [SerializeField] private Button closeButton2;
    [Header("Panels")]
    [SerializeField] private GameObject helpPanel;
    [SerializeField] private GameObject creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        quitButton.onClick.AddListener(QuitButton);
        startButton.onClick.AddListener(StartButton);
        helpButton.onClick.AddListener(HelpButton);
        creditsButton.onClick.AddListener(CreditsButton);
        closeButton1.onClick.AddListener(CloseButton);
        closeButton2.onClick.AddListener(CloseButton);
        creditsPanel.SetActive(false);
        helpPanel.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Level 1");
		print("Start Button Clicked");
    }
	public void HelpButton()
    {
        helpPanel.SetActive(true);
        print("Help Button Clicked");
    }
	public void CreditsButton()
    {
        creditsPanel.SetActive(true);
        print("Credits Button Clicked");
    }
    public void QuitButton()
    {
        Application.Quit();
		print("Quit Button Clicked");
    }
    public void CloseButton()
    {
        creditsPanel.SetActive(false);
        helpPanel.SetActive(false);
        print("Close Button Clicked");
    }
}
