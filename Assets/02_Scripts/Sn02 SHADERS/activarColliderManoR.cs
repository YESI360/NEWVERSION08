using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarColliderManoR : MonoBehaviour
{

    public SphereCollider manoR;

    void Start()
    {
        manoR = GetComponent<SphereCollider>();
        manoR.enabled = false;
        manoR.radius = 0f;

    }

    public void agrandarCollidermanoR()
    {
        manoR.enabled = true;
        manoR.radius = 1f;

    }

    void Update()
    {
        if (Input.GetKeyDown("r")) // (Input.GetKey("1"))//
        {
            agrandarCollidermanoR();
        }

    }


}
