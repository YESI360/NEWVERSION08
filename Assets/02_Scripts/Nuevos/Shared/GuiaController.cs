using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiaController : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        // Si es la mano derecha
        if (other.CompareTag("hands1"))
        {
            ShaderManager.instance.ExecuteInstruction(Sn_02_Instructions_Steps_enum.Instruction_05);
        }
    }

}
