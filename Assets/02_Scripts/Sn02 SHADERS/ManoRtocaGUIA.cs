using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManoRtocaGUIA : MonoBehaviour
{
    public ShaderSB3 limit;//alCollider se pone TRUE="LUZLIMIT"

    public void OnTriggerEnter(Collider other)//MANO toca guia
    {
        if (other.CompareTag("objGuia") )// && !InAvatar)//|| collider.gameObject.tag == "objGuia")
        {

            Debug.Log("SE TOCAN Y TRUE");

            if(!SoundManagerGuia.instance.IsPlaying && limit.alCollider == true)//solo dsd "LUZLIMIT"=TRUE
                SoundManagerGuia.instance.PlayInstruccion05();//put hands waits

            //si PONGO MANOS CINTURA///////////////////////////////////////collider capsule
            //avatar.mirrorFake(); //veo avatar fake 8 
            //flow.SetState(GameState1.Belly1);//////////////////////////         

        }
    }

    private void OnTriggerExit(Collider other)//si dejo de colisionar no pasa nada!
    {
        //if (other.CompareTag("objGuia") && InAvatar)//|| collider.gameObject.tag == "objGuia")
        //{
        //    InAvatar = false;
        //    SoundManagerGuia.instance.Stop();
        //}
    }
}

    