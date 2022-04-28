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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteractions : MonoBehaviour
{
    private GameObject raycastedObj;
    [SerializeField] GameObject player;
    [SerializeField] Transform elevatorLocation;
    [SerializeField] GameObject levelTrigger;
    [SerializeField] string nextScene;
    [SerializeField] GameObject[] monsters;
    [SerializeField] GameObject[] triggers;

    [SerializeField] private float rayLength = 2.5f;
    [SerializeField] private LayerMask layerMaskInteract;


    [SerializeField] Image crosshairIcon_Default;
    [SerializeField] Image crosshairIcon_Interact;
    [SerializeField] Image solidBlack;
    [SerializeField] Text infoText;
    [SerializeField] Text dayText;

    public int numberOfTerminals;

    void Start()
    {
        ResetCrosshair();
        infoText.text = "";
        numberOfTerminals = 0;
        StartCoroutine(StartDay());
    }

    IEnumerator StartDay()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FadeImage(true));
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, layerMaskInteract.value))
        {
            if (hit.collider.CompareTag("Terminal"))
            {
                CrosshairInteract();
                print("Hitting terminal");
                raycastedObj = hit.collider.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                    Collider screenCollision = raycastedObj.GetComponent<Collider>();
                    screenCollision.enabled = false;
                    GameObject screenOverlay = raycastedObj.transform.Find("Overlay").gameObject;
                    screenOverlay.SetActive(true);
                    numberOfTerminals++;
                    infoText.text = "Remaining Terminals: " + (3 - numberOfTerminals);
                    CheckMonitors();
                }
            }
            if (hit.collider.CompareTag("Elevator"))
            {
                CrosshairInteract();
                print("Hitting Elevator");
                raycastedObj = hit.collider.gameObject;
                if (Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(FadeImage(true));
                    player.transform.position = elevatorLocation.transform.position;
                    infoText.text = "Remaining Terminals: 3";
                }
            }
            if (hit.collider.CompareTag("MonsterTrigger"))
            {
                print("Enabled Monsters");
                foreach (GameObject enemy in monsters)
                {
                    enemy.SetActive(true);
                }
                foreach (GameObject trigger in triggers)
                {
                    Destroy(trigger);
                }
            }
            if (hit.collider.CompareTag("NextLevel"))
            {
                print("Next Level");
                StartCoroutine(FadeImage(false));
                StartCoroutine(DelayTransition());
            }
        }
        else
        {
            CrosshairDefault();
        }

    }

    void ExternalFade()
    {
        StartCoroutine(FadeImage(false));
    }

    void CheckMonitors()
    //If all terminals have been activated, return to the elevator.
    {
        if (numberOfTerminals == 3)
        {
            infoText.text = "Return to the elevator";
            levelTrigger.SetActive(true);
        }
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeAway == true)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                solidBlack.color = new Color(1, 1, 1, i);
                yield return null;
            }
            dayText.text = "";
        }
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                solidBlack.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    IEnumerator DelayTransition()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nextScene);
    }

    private void CrosshairDefault()
    //If the player can't interact with anything, display the default crosshair.
    {
        ResetCrosshair();
        crosshairIcon_Default.enabled = true;
    }

    private void CrosshairInteract()
    //If the player can interact with something, display an interaction crosshair.
    {
        ResetCrosshair();
        crosshairIcon_Interact.enabled = true;
    }

    private void ResetCrosshair()
    {
        crosshairIcon_Default.enabled = false;
        crosshairIcon_Interact.enabled = false;
    }
}
