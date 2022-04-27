using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autosMoving : MonoBehaviour
{
    public float movementSpeed;

    private Vector3 target = new Vector3(-276, 37, 400);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveAutos();
    }

    public void MoveAutos()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
    }
}
