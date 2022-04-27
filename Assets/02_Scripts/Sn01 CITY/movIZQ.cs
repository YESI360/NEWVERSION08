using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundController))]
public class movIZQ : MonoBehaviour
{
    public GameObject CubeVocesIZQ;
    public float movementSpeed;
    public float SpeedVol;
    public AudioSource Voces;

    private Vector3 target = new Vector3(-147, 139, -163);
    private Vector3 target2 = new Vector3(81, 139, -38);

    private void Start()
    {
        GetComponent<AudioSource>().volume = 1;
    }
    void Update()
    {
        MoveGameObject1();

    }
    public void VolumenDown()
    {
        Voces.volume -= Time.deltaTime * SpeedVol;
       // Voces.volume = 0.6f;
    }
    public void MoveGameObject1()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
        
    }

    public void MoveGameObject2()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target, movementSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards (target, target2, movementSpeed * Time.deltaTime);
        Debug.Log("moveGO2");
        
    }


}
