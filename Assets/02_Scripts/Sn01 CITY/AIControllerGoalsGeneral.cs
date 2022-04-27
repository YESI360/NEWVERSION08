using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIControllerGoalsGeneral : MonoBehaviour
{
    [SerializeField] string goals;
    public float speed;
    GameObject[] goalLocations;
    [SerializeField] Vector3[] dieLocations;
    NavMeshAgent agent;
    Animator anim;

    bool onDestroy;

    void Start()
    {
        goalLocations = GameObject.FindGameObjectsWithTag(goals);
        agent = this.GetComponent<NavMeshAgent>();       
        agent.SetDestination(goalLocations[Random.Range (0, goalLocations.Length)].transform.position);

        anim = this.GetComponent<Animator>();
        anim.Play("RunningInPlace");
    }

    private void Update()
    {
        transform.Translate(0, 0, speed);
        //Debug.Log("transf : " + transform);

        if (onDestroy)
        {
            //if (agent.remainingDistance != Mathf.Infinity && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance < 6)
                Destroy(gameObject);
        }
        else if(agent.remainingDistance < 3)
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
    }

    public void Destroy()
    {
        //anim.Play("RunningInPlace");
        speed = 2f;
        agent.SetDestination(dieLocations[Random.Range(0, dieLocations.Length)]);/////
        onDestroy = true;
    }

    public void ChangeState()
    {
        anim.Play("walking");
        speed = .5f;
    }

    public void PlayRun(string animName, float speed)
    {
        anim.Play(animName);
        this.speed = speed;
    }
}
