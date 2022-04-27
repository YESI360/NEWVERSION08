using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CinturaCollider : MonoBehaviour
{
    public GameObject objGuia;
    public GameObject handRed;//1
    public GameObject handBlue;//2
    public GameObject sphereBelly;
    public GameObject planeMirror;//espejo real

    public ChangeMat mirror;//cambia texturas espejos
    public bool espejoOn;
    public bool hands1;//= true;
    public bool hands2;// = true;
    public bool guia;

    public bool manoscintura;
    public bool InAvatar2;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;

    private MeshRenderer meshRenderer;

    public FlowCal flowcal;

    private void Awake()//start?
    {
        meshRenderer = GetComponent<MeshRenderer>();//salvavidas
        planeMirror.SetActive(false); //espejo real
        sphereBelly.SetActive(false);//empieza desactivada
        //planeMirror.SetActive(false);//empieza desactivada NO FUNCA; LO HAGO A MANO
    }

    public void Start()
    {
        InAvatar2 = true;
    }

    void Update()/////////////////////BOTONERA
    {
        if (Input.GetKeyDown("5"))//DEBUG prendo espejo real PLANO (PUERTA NEGRA)
        {
            planeMirror.SetActive(true);
            Debug.Log("espejoReal");
        }
        if (Input.GetKeyDown("6"))//llamo funcion del espejo falso PARA VER EL AVATAR ESTATICO
        {
            mirror.mirrorFake();
            Debug.Log("espejoReal");
        }
        if (Input.GetKeyDown("7"))////////dejo de ver AVATAR FAKE
        {
            mirror.mirrorAvatar();
            Debug.Log("CHANGE MAT");
        }
        ////////////////////////////////////////////
        if (Input.GetKeyDown("z"))//DEBUG ver sphere belly
        {
            sphereBelly.SetActive(true);
            Debug.Log("SPHERE BELLY");
        }
        if (Input.GetKeyDown("x"))//DEBUG ver capsula
        {
            GetComponent<MeshRenderer>().enabled = true;
            Debug.Log("salvavidas");
        }
        if (Input.GetKeyDown("c"))//DEBUG dejar ver capsula
        {
            GetComponent<MeshRenderer>().enabled = false;
            Debug.Log("salvavidas");
        }
        if (Input.GetKeyDown("9"))//DEBUG MANOS CINTURA
        {
            manoscintura = true;
            Debug.Log("ManosWaist");
        }


    }

    public void OnTriggerStay (Collider other)//OnTriggerStay how long?
    {
        if (other.gameObject.tag == "hands1")//handRed toca cintura
        {
            hands1 = true;
            //Debug.Log("hands1");               
        }

        if (other.gameObject.tag == "hands2")//handBlue toca cintura
        {
            hands2 = true;
            //Debug.Log("hands2");          
        }

        if (other.gameObject.tag == "objGuia")// guia toca cintura
        {
            guia = true;
            Debug.Log("guia");
        }

        if (hands1 == true && hands2 == true)//////2 MANOS EN LA CINTURA 
        {
            hands2 = false;
            hands1 = false;
            Debug.Log("HANDRED+BLUE");

            planeMirror.SetActive(true);//se prende espejo real
            mirror.mirrorFake();//llamo funcion del espejo falso PARA VER EL AVATAR ESTATICO//DESCOMENTAR VER AVATAR REAL mover CamMirrorFake posX-147.3
            manoscintura = true;
            ////////////////VER CAPSULA SOLO PARA DEBUG
            GetComponent<MeshRenderer>().enabled = true;
            meshRenderer.material.color = enterColor;//pinta SALVAVIDAS rojo
        }


        if (manoscintura == true && InAvatar2 && !SoundManagerGuia.instance.IsPlaying)
        {
            SoundManagerGuia.instance.PlayInstruccion06();
            InAvatar2 = false;
            flowcal.SetState(GameState1.Belly1);////////////////////////// 
        }

    }

    private void OnTriggerExit(Collider other)///////SACO LAS MANOS y no hace nada!
    {
    //    meshRenderer.material.color = normalColor;//salvavidas CAMBIA COLOR AL SACAR MANOS
    //    //hands2 = false;
    //    //hands1 = false;

    //    if (other.gameObject.tag == "hands1") hands1 = false;
    //    if (other.gameObject.tag == "hands2") hands2 = false;

    //    //planeMirror.SetActive(false);//se APAGA espejo real
    //    //mirror.mirrorAvatar();//llamo funcion del espejo real PARA Q SE APAGUE


    }





}
