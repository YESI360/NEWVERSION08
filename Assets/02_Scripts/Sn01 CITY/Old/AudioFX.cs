using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public GameObject SoundsGO;

    public GameObject spawnM4BGO;//declaro go
    public spawnM4B pasosScript;//quiero acceder al scrpit

    //public GameObject SpawnFemPINK;// de este GO 1quiero el prefab /2quiero si audios
    //public SpawnerF22 f22Script;// de ese script SE ROMPE EL SPAWN...



    void Start()
    {
        SoundsGO = GameObject.Find("Sounds");

        spawnM4BGO = GameObject.Find("spawnM4B");
        //pasosScript = spawnM4BGO.GetComponent<pasos>();
        pasosScript = spawnM4BGO.GetComponent<spawnM4B>();


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundsGO.GetComponent<AudioSource>().Stop();

            //pasosScript.StopPasos();
            //pasosScript.GetComponent<AudioSource>().Stop();
            Debug.Log("paro");
        }

        if (Input.GetKeyDown("space"))
        {
            SoundsGO.GetComponent<AudioSource>().Play();
            //pasosScript.PlayPasos();
            //pasosScript.GetComponent<AudioSource>().Play();
            Debug.Log("playAgain");
        }
    }
}
