using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apagarSphereL : MonoBehaviour
{
    public MeshRenderer footMesh;
    void Start()
    {
        footMesh = GetComponent<MeshRenderer>();
        footMesh.enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void apagarfoot()
    {
        footMesh.enabled = false;
    }
}
