using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSB3b : MonoBehaviour
{
    Renderer rend;
    //public float manosLim;
    //public float mirrorLimt;
    //public float luzLimt;
    //public float guiaLimt;
    //public LuzAmb luzAmb; 
    //public LuzHandL luzmanoL;
    //public LuzHandR luzmanoR;
    //public LuzGuia luzguia;
    //public Guia instrucciones;
    //bool manos;
    //public tocar3 espejo;
    //public ChangeMat avatar;

    public int steps = 10;
    public float targetValueDownIncreaseStep;
    public float targetValueUp;
    public float targetValueDown;

    public float MaxContribution;
    //public float MinContribution;
    public float MinContributionNew;//start in black
    public int MinContributionCount;
    public float VelContribution;
    public float currentValue;
    [Range(0.210f, 1)] public float lerpedValue;

    public float lerpSpeedUp;
    public float lerpSpeedDown;
    private float lerpSpeedUpNew;
    private float lerpSpeedUpCount;
    public float lerpSpeedUpVel;

    bool entrada;

    void Start()
    {
        
        targetValueDownIncreaseStep = (targetValueUp - targetValueDown) / steps;
        //targetValueDownIncreaseStep = 0.210f;

        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_ZeroValue");

        MaxContribution = 1;
        //MinContribution = 0;
        targetValueUp = 1;
        targetValueDown = 0;
        MinContributionNew = 0.181f;//0.210f; //=1 resp
        lerpSpeedUpCount = 0;
        MinContributionCount = 0;
    }

    void Update()
    {
        if (Input.GetKey("6")) // (Input.GetKeyDown("1"))//
        {
            MinContributionNew = 0.500f ;
            Debug.Log("ver");
        }
    }
    public void LuzUp()
    {
        lerpedValue = Mathf.Lerp(currentValue, targetValueUp, Time.deltaTime * lerpSpeedUpNew);

        currentValue = Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution);

        rend.material.SetFloat("_ZeroValue", currentValue);

        lerpSpeedUpCount = lerpSpeedUpCount + 1; // So you add to the count everytime you go into this function, if it executes once when you have a new breath
        lerpSpeedUpNew = lerpSpeedUpCount * lerpSpeedUpVel; // So this increases by 0.2f everytime this function is called

        MinContributionCount = MinContributionCount + 1;
        entrada = true;
        //Debug.Log("true first input");

        //MinContributionNew = MinContributionCount * VelContribution;

        if (entrada == true)
        {
            MinContributionNew = 0.199f;
        }
        MinContributionNew = MinContributionCount * VelContribution;

        /*
        //if (entrada == true)
        //{

        if (MinContributionNew >= manosLim)
        {
            Debug.Log("manos");
            luzmanoL.luzHandL();
            luzmanoR.luzHandR();
            manos = true;
        }

        if (manos == true)
        {

        }

        if (MinContributionNew >= mirrorLimt)
        {
            espejo.planeMirror.SetActive(true);//espejo PUERTA  NEGRA 5
            Debug.Log("espejoReal");
        }

        if (MinContributionNew >= luzLimt)
        {
            Debug.Log("luzAmb");
            luzAmb.luzUp();
        }

        if (MinContributionNew >= guiaLimt)
        {
            Debug.Log("guia");
           instrucciones.instruccion03();//estas bien? soy yo. guia
        }

        if (MinContributionNew >= avatarLimt)
        {
            Debug.Log("avatar");
            espejo.mirror.mirrorFake();
            instrucciones.instruccion04();//mano, pararte
            //instruccion belly
        }

        //}

        
         si me pongo mano en cintura (4) = veo avatar = mirror.mirrorFake();
        empiezo instrucciones respirarar belly
        instrucciones.instruccion05();//cintura. movimiento
        instrucciones.instruccion06();//panza globo
        luz belly
         */

        var potentialNextValue = Mathf.Clamp(targetValueDown + targetValueDownIncreaseStep, 0, targetValueUp);

        if (currentValue >= potentialNextValue)
        {
            targetValueDown = potentialNextValue;
        }

    }


    public void LuzDown()
    {

        lerpedValue = Mathf.Lerp(currentValue, targetValueDown, Time.deltaTime * lerpSpeedDown);

        rend.material.SetFloat("_ZeroValue", Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution));

        currentValue = rend.material.GetFloat("_ZeroValue");
    }

}
