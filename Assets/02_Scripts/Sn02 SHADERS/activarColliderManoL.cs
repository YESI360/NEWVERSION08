using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarColliderManoL : MonoBehaviour
{

    public SphereCollider manoL;

    void Start()
    {
        manoL = GetComponent<SphereCollider>();
        manoL.enabled = false;
        manoL.radius = 0f;

    }

    public void agrandarCollidermanoL()
    {
        manoL.enabled = true;
        manoL.radius = 1f;

    }

    void Update()
    {
        if (Input.GetKeyDown("l")) // (Input.GetKey("1"))//
        {
            agrandarCollidermanoL();
        }

    }


}
