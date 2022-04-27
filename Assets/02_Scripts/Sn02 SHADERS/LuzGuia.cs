using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzGuia : MonoBehaviour
{
    Light myLight;
    public float range;
    public float rangeMult;
    //public float RangeLimit;

    //public float IntensityLimit;
    public float Intensity;
    public float speedIn;
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = 0;
        myLight.range = 0;
        
    }

    void Update()
    {
        if (Input.GetKeyDown("4")) // (Input.GetKey("1"))//
        {
            luzUpGuia();
        }

    }

    public void luzUpGuia()
    {
        //if (myLight.intensity < IntensityLimit)
        //{
            myLight.intensity = Mathf.Lerp(myLight.intensity, Intensity, speedIn * Time.deltaTime);
        //}

        //if (myLight.range < RangeLimit)
        //{
            myLight.range += range * rangeMult * Time.deltaTime;//IMPORTA MAS RANGE

        //}
        

    }
}
