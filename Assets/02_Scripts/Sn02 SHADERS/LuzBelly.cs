using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuzBelly : MonoBehaviour
{
    Light myLight;

    public float range;
    public float rangeMult;
    public float RangeLimit;

    public float speedIn;
    public float IntensityLimit;
    public float Intensity;

    public float speedDown;
    public float maxneg;


    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = 0;
        myLight.range = 0;
    }

    void Update()
    {
        if (Input.GetKey("8")) // (Input.GetKeyDown("1"))//
        {
            luzUpBELLY();
        }
        //if (Input.GetKey("9")) // (Input.GetKeyDown("1"))//
        //{
        //    luzDownB();
        //}

    }

    public void luzUpBELLY()
    {
        //Debug.Log("luzbelly");

        //myLight.intensity = Mathf.PingPong(Time.time, 8);
        //myLight.range = Mathf.PingPong(Time.time, 8);

        if (myLight.intensity < IntensityLimit)
        {
            myLight.intensity = Mathf.Lerp(myLight.intensity, Intensity, speedIn * Time.deltaTime);
        }

        if (myLight.range < RangeLimit)
        {
            myLight.range = Mathf.Lerp(myLight.range, range, rangeMult * Time.deltaTime);
            //myLight.range += range * rangeMult * Time.deltaTime;
        }


    }
    public void luzDownB()
    {
        //myLight.range -= range * maxneg * Time.deltaTime;
        myLight.intensity = Mathf.Lerp(myLight.intensity, maxneg, speedDown * Time.deltaTime);
        myLight.range = Mathf.Lerp(myLight.range, maxneg, speedDown * Time.deltaTime);

        //myLight.range -= range * rangeMult * Time.deltaTime;//IMPORTA MAS RANGE
        //myLight.intensity = Mathf.Lerp(myLight.intensity, maxneg, speed * Time.deltaTime);//le hago sped y max-min para range separado de intensity??

    }



}
