using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using UnityEngine.Events;


public class MyMessageListenerCITY : MonoBehaviour {

    public GameObject sphereBelly;
    public GameObject sphereChest;
    public PDSensorCity synth;

    public Text belly;
    public Text chest;

    public float datoNormCC;
    public float datoNormCB;
    public int datoL = 0;
    public int datoL2 = 0;
    private int datoP = 0;
    private int datoPant = 0;
    private int stepsL = 0;
    private int stepsLAnt = 0;

    private int speed;
    private int max;

    string[] vec1;

    void Start () 
    {
    }
	
    void Update () {
    }

    public void OnMessageArrived(string msg)
    {
        //Debug.Log("Arrived: " + msg);

        vec1 = msg.Split(',');

        string c1 = "chest";
        string c2 = (vec1[0]);
        string b1 = "belly";
        string n1 = "CC";
        string n2 = "CB";

        if ((String.Compare(c1, c2)) == 0)//chest to vec
        {
            datoL2 = (Convert.ToInt32(vec1[1]));//CHEST
            //Debug.Log("chest:" + datoL2);
        }
        else if ((String.Compare(b1, c2)) == 0)//belly to vec
        {
            datoL = (Convert.ToInt32(vec1[1]));//belly  
            //Debug.Log("belly:" + datoL);
        }
        else if ((String.Compare(n1, c2)) == 0)//norm to vec
        {
            datoNormCC = float.Parse(vec1 [1]);          
            //Debug.Log("calibracion:" + datoNormCC);
        }
        else if ((String.Compare(n2, c2)) == 0)//norm to vec
        {
            datoNormCB = float.Parse(vec1[1]);
            //Debug.Log("calibracion:" + datoNormCB);
        }

        ///////////////////////////////////////////////txt 
        belly.text = "belly: " + datoL;
        chest.text = "chest: " + datoL2;
        ///////////////////////////////////////PECHO////////////CHEST//////////////L2//////////////////////////////////CHEST
        if (datoL2 == 2) //(flowManager.CurrentState == GameState.Chest && datoL2 != datoL2ant)
        {
            sphereChest.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime);
            synth.SoundUp();
        }
        else
        {
            sphereChest.transform.localScale = new Vector3(3, 3, 3);
            synth.SoundDown();
        }

        ////////////////////PANZA////////////BELLY//////////////////////////L//////////////////////BELLY  
        if (datoL == 2)//(flowManager.CurrentState == GameState.Belly && datoL == BELLY_INHALE)
        {
            sphereBelly.transform.localScale += new Vector3(3, 3, 3) * 2 * (Time.deltaTime);

        }
        else
        {
            sphereBelly.transform.localScale = new Vector3(3, 3, 3);
        }

    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}
