using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControllerGoalsFR : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator anim;

    public float speed;

    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("GoalsR");
        agent = this.GetComponent<NavMeshAgent>();       
        agent.SetDestination(goalLocations[Random.Range (0, goalLocations.Length)].transform.position);

        anim = this.GetComponent<Animator>();
        anim.SetTrigger("Moving");

    }

    private void Update()
    {
        transform.Translate(0, 0, speed);

        if (agent.remainingDistance < 3)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }
}
