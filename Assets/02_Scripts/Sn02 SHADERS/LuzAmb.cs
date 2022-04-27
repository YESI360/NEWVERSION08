using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzAmb : MonoBehaviour
{
    Light myLight;
    public float speed;
    public float LimitUp;
    public float Intensity;
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.intensity = 0;
      
    }

    void Update()
    {
        if (Input.GetKeyDown("2")) // (Input.GetKeyDown("1"))//
        {
            luzUp();
        }

    }

    public void luzUp()
    {
        if (myLight.intensity < LimitUp)
        {
            myLight.intensity = Mathf.Lerp(myLight.intensity, Intensity, speed * Time.deltaTime);
        }
    }
}
