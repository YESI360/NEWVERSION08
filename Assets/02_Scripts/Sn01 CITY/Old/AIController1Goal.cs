using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController1Goal : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    Animator anim;
    public int speed;
    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goals");
        agent = this.GetComponent<NavMeshAgent>();       
        agent.SetDestination(goalLocations[Random.Range (0, goalLocations.Length) * speed].transform.position);
        anim = this.GetComponent<Animator>();    
        anim.SetTrigger("jump");


    }

    private void Update()
    {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetBool("isJumping", true);
        }

        else
        {
            anim.SetBool("isJumping", false);
        }


        //if (Input.GetButtonDown("Fire1"))
        //{
        //    anim.SetBool("isJumping", false);
        //}

        //si pongo DOBLE Y a mano isJumping a F, camina




    }


}
