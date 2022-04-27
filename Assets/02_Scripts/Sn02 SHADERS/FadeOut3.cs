using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FadeOut3 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("space"))
        {
            SteamVR_LoadLevel.Begin("03_ForestNEW");
        }
    }

}
