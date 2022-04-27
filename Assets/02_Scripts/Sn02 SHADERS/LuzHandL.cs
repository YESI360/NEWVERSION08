using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzHandL : MonoBehaviour
{
    Light myLight;
    public float range;
    public float rangeMult;
    public float RangeLimit;

    public float IntensityLimit;
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
        if (Input.GetKey("3")) // (Input.GetKeyDown("1"))//
        {
            myLight.intensity = 3;
            myLight.range = 2;
        }

    }

    public void luzHandL()
    {
        if (myLight.intensity < IntensityLimit)
        {
            myLight.intensity = Mathf.Lerp(myLight.intensity, Intensity, speedIn * Time.deltaTime);
        }

        if (myLight.range < RangeLimit)
        {
            myLight.range += range * rangeMult * Time.deltaTime;//IMPORTA MAS RANGE

        }
    }
}
