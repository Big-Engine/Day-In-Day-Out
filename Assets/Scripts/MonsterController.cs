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
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    enum AIState { wandering, chasing, attacking };

    AIState currentState;

    NavMeshAgent agent;
    [SerializeField] GameObject player;
    [SerializeField] int destinationIndex;
    [SerializeField] GameObject[] checkpoints;
    [SerializeField] Image solidBlack;
    [SerializeField] GameObject deathPanel;
    FirstPersonAIO firstPersonAIO;

    [SerializeField] string sceneName;

    void Start()
    {
        firstPersonAIO = player.GetComponent<FirstPersonAIO>();
        currentState = AIState.wandering;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        destinationIndex = Random.Range(0, 5);
        agent.SetDestination(checkpoints[destinationIndex].transform.position);
        HandleStates();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < 2.0f)
        {
            currentState = AIState.attacking;
        }
        else if (distanceToPlayer < 15.0f)
        {
            currentState = AIState.chasing;
        }
        else
        {
            currentState = AIState.wandering;
        }
        HandleStates();
    }

    void HandleStates()
    {
        switch (currentState)
        {
            case AIState.wandering:
                print("Wandering");
                float distanceToCheckpoint = Vector3.Distance(checkpoints[destinationIndex].transform.position, transform.position);
                if (distanceToCheckpoint < 2f)
                {
                    destinationIndex = Random.Range(0, 5);
                    agent.SetDestination(checkpoints[destinationIndex].transform.position);
                    print("Going to pathpoint " + checkpoints[destinationIndex]);
                }
                else
                {
                    agent.SetDestination(checkpoints[destinationIndex].transform.position);
                }
                break;
            case AIState.chasing:
                print("Chasing");
                agent.SetDestination(player.transform.position);
                break;
            case AIState.attacking:
                print("Attacking: The player has died.");
                StartCoroutine("Pause");
                firstPersonAIO.playerCanMove = false;
                firstPersonAIO.enableCameraMovement = false;
                StartCoroutine("FadeInFadeOut");
                break;
            default:
                print("Error in HandleStates");
                break;
        }
    }

    private IEnumerator Pause()
    //After the enemy attacks, they freeze while the player dies.
    {
        agent.isStopped = true;
        yield return null;
    }

    private IEnumerator FadeInFadeOut()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            solidBlack.color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(3.0f);
        deathPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            solidBlack.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
