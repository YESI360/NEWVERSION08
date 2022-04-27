using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSB4 : MonoBehaviour
{
    Renderer rend;

    public float manosLim;
    public float luzLimt;
    public LuzAmb luzAmb;
    public LuzHandL luzmanoL;
    public LuzHandR luzmanoR;
    bool manos;
    public CinturaCollider espejo;
    public ChangeMat avatar;

    public float lerpedValue = 0.156f;
    public float targetValue = 0.156f;
    public int steps = 6;
    public float stepAmount;
    [Range(0, 1)] public float lerpSpeed = 0.05f;

    public bool IsAnimating;
    private float currentValue;
    private Coroutine distortionCoroutine;

    public float MaxContribution;
    public float MinContribution;
    public float MinContributionNew;//start in black

    void Start()
    {
        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_ZeroValue");
        stepAmount = (currentValue - MinContribution) / steps;
        MaxContribution = currentValue;

        MinContributionNew = 0.181f;//0.210f; //=1 resp
    }

    void Update()
    {
        if (Input.GetKey("6")) // (Input.GetKeyDown("1"))//
        {
            AnimateToNextState();
            //MinContributionNew = 0.500f ;
            Debug.Log("ver");
        }
    }

    public void AnimateToNextState()
    {
        if (IsAnimating) return;

        if (distortionCoroutine != null)
        {
            StopCoroutine(distortionCoroutine);
        }

        distortionCoroutine = StartCoroutine(LerpDistortionShader());
    }
    private IEnumerator LerpDistortionShader()
    {
        IsAnimating = true;

        currentValue = rend.material.GetFloat("_ZeroValue");
        targetValue = currentValue - stepAmount;

        while (Mathf.Abs(currentValue - targetValue) > 0.001f)
        {

        lerpedValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * lerpSpeed);

        rend.material.SetFloat("_ZeroValue", Mathf.Clamp(lerpedValue, MinContribution, MaxContribution));

        currentValue = rend.material.GetFloat("_ZeroValue");

        yield return new WaitForEndOfFrame();
        }

        IsAnimating = false;


        /*
               lerpSpeedUpCount = lerpSpeedUpCount + 1; // So you add to the count everytime you go into this function, if it executes once when you have a new breath
               lerpSpeedUpNew = lerpSpeedUpCount * lerpSpeedUpVel; // So this increases by 0.2f everytime this function is called

               MinContributionCount = MinContributionCount + 1;
               entrada = true;
               MinContributionNew = MinContributionCount * VelContribution;


               if (MinContributionNew >= manosLim)
               {
                   Debug.Log("manos");
                   luzmanoL.luzHandL();
                   luzmanoR.luzHandR();
                   manos = true;
               }

               if (manos == true)
               {
                   espejo.planeMirror.SetActive(true);//espejo PUERTA  NEGRA 5
                   Debug.Log("espejoReal");
               }

               if (MinContributionNew >= luzLimt)
               {
                   Debug.Log("luzAmb");
                   luzAmb.luzUp();
               }

               /*
                si me pongo mano en cintura (4) = veo avatar = mirror.mirrorFake();
               empiezo instrucciones respirarar belly
               luz belly
                */



    }




}
