using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTrans : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle;
    private bool estaAndando = false;
    private float TransparencyLevel;
    public float speed;
    Renderer rend;
    public FlowManager flow;
    //public int time;


    void Start()
    {
        //vrCamera = Camera.main.transform;
        rend = GetComponent<Renderer>();
        //GetComponent<MeshRenderer>().enabled = true;
        rend.enabled = false;
        TransparencyLevel = 0;

    }

    void Update()
    {
        if (Input.GetKey("5"))
        {
            float currentValue = rend.material.GetFloat("_Alpha");
            rend.enabled = true;
            Debug.Log("ActivaBody");
            TransparencyLevel += Time.deltaTime / speed;
            rend.material.SetFloat("_Alpha", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
        }

        if (flow.CurrentState == GameState.Belly)
        {
            rend.enabled = true;
            //Debug.Log("cuerpoActivo");
        

        //StartCoroutine( ActivarBody() );

        float currentValue = rend.material.GetFloat("_Alpha");

        if (!estaAndando && MiraAbajo)
        {
            Debug.Log("mira");
            rend.enabled = true;
            TransparencyLevel += Time.deltaTime / speed;
            rend.material.SetFloat("_Alpha", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));

        }
        else if (!MiraAbajo)
        {
            currentValue = 1;
            //TransparencyLevel = TransparencyLevel / speed *  Time.deltaTime;
            //rend.material.SetFloat("_Alpha", Mathf.Lerp(currentValue, TransparencyLevel, Time.deltaTime));
            //myLight.range = myLight.range - (range / 4) * Time.deltaTime;
        }



    }


    }

    //IEnumerator ActivarBody ()
    //{
    //    if (flow.CurrentState == GameState.Belly)
    //    {
    //        rend.enabled = true;       
    //        Debug.Log("cuerpoActivo");
    //    }
    //    yield return new WaitForSeconds(time);

    //}

    public bool MiraAbajo
    {
        get
        {
            return vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f; //la cam X esta entre 30 y 90 
            //return vrCamera.eulerAngles.x <= 40 && vrCamera.eulerAngles.x < 90.0f; //la cam X esta entre 30 y 90           
        }



    }



}
 
