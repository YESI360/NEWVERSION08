using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{
    public GameObject goal;
    NavMeshAgent agent;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.transform.position);

    }
}
