using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarColliderGuia : MonoBehaviour
{

    public SphereCollider guia;

    void Start()
    {
        guia = GetComponent<SphereCollider>();
        guia.enabled = false;
        guia.radius = 0f;

    }

    public void agrandarCollider()
    {
        guia.enabled = true;
        guia.radius = 1f;

    }

    void Update()
    {
        if (Input.GetKeyDown("q")) // (Input.GetKey("1"))//
        {
            agrandarCollider();
        }

    }


}
