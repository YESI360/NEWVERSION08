using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class AlphaSH : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM7", 9600);//test nano
    public float TransparencyLevel;
    public float speed;
    Renderer rend;

    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 1;
        rend = GetComponent<Renderer>();

    }

    void Update()
    {
        float currentValue = rend.material.GetFloat("_Alpha");        

        if (serialPort.IsOpen)
        {
            try
            {
                string value = serialPort.ReadLine();
                print(value);
                string[] vec1 = value.Split(',');

                if ((Convert.ToInt32(vec1[0])) == 1) 
                {
                    Debug.Log("change1");               
                    TransparencyLevel += Time.deltaTime / speed;
                    rend.material.SetFloat("_Alpha", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
                }
                else  
                {
                    Debug.Log("change2");
                    TransparencyLevel -= Time.deltaTime * speed;
                    rend.material.SetFloat("_Alpha", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
                }
                serialPort.BaseStream.Flush();
            }
            catch (System.Exception)
            {

            }
        }
    }
}
