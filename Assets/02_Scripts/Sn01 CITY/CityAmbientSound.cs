using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Incrementa el volumen del ambiente de la ciudad y a partir de un paso de las instrucciones comienza a bajarlo

public class CityAmbientSound : MonoBehaviour
{
    public CityInstructions instrucciones;
    public AudioSource Voces;
    public float SpeedUp;
    public float SpeedDown;
    //public float maxVolume = 0.5f;
    bool maximo;


    void Start()
    {
        //GetComponent<AudioSource>().volume = 0;
    }
    void Update()
    {

        Voces.volume += Time.deltaTime * SpeedUp;

        if (instrucciones.actualStep == Sn_01_Instructions_Steps_enum.Step1)//(Voces.volume >= maxVolume)
        {
        maximo = true;
        }

       if (maximo == true)
       Voces.volume -= Time.deltaTime * SpeedDown;

    }



}
