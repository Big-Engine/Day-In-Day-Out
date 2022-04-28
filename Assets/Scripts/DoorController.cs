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

public class DoorController : MonoBehaviour
{
    public GameObject button;
    public Transform door;
    public Transform startPosition;
    public Transform endPosition;
    public Vector3 newPosition;
    public float smooth;
    public bool isOpen = false;
    public bool isLocked;
    public int securityLevel;

    void Start()
    {
        newPosition = startPosition.transform.position;
        Renderer buttonState = button.GetComponent<Renderer>();
        buttonState.material.color = Color.yellow;
        if (isLocked == true)
        {
            buttonState.material.color = Color.red;
        }
    }

    void FixedUpdate()
    {
        door.position = Vector3.MoveTowards(door.transform.position, newPosition, smooth * Time.deltaTime);
    }

    public void ToggleDoor()
    {
        if (isLocked == false)
        {
            if (isOpen == false)
            {
                isOpen = true;
                Renderer buttonState = button.GetComponent<Renderer>();
                buttonState.material.color = Color.green;
                newPosition = endPosition.transform.position;
                print("Door Opened");
            }
            else
            {
                isOpen = false;
                Renderer buttonState = button.GetComponent<Renderer>();
                buttonState.material.color = Color.yellow;
                newPosition = startPosition.transform.position;
                print("Door Closed");
            }
        }
        else
        {
            Renderer buttonState = button.GetComponent<Renderer>();
            buttonState.material.color = Color.red;
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
        Renderer buttonState = button.GetComponent<Renderer>();
        buttonState.material.color = Color.yellow;
    }
}
