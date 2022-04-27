using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSB2 : MonoBehaviour
{
    Renderer rend;

    public float MaxContribution;
    public float MinContribution;
    public float MinContributionNew;
    public int MinContributionCount;
    public float VelContribution; 
   
    private float currentValue;
    [Range(0, 1)] public float lerpedValue;

    public float targetValueUp;
    public float targetValueDown;

    public float lerpSpeedUp;
    public float lerpSpeedDown;

    void Start()
    {
        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_ZeroValue");

        MaxContribution = 1;
        MinContribution = 0;
        targetValueUp = 1;
        targetValueDown = 0;
        MinContributionNew = 0.0001f;
        MinContributionCount = 0;
    }

    void Update()
    {
    }


    public void LuzUp()
    {
            currentValue = rend.material.GetFloat("_ZeroValue");
 
            lerpedValue = Mathf.Lerp(currentValue, targetValueUp, Time.deltaTime * lerpSpeedUp);

            rend.material.SetFloat("_ZeroValue", Mathf.Clamp(lerpedValue, MinContribution, MaxContribution));

            currentValue = rend.material.GetFloat("_ZeroValue");

     MinContributionCount = MinContributionCount + 1; // So you add to the count everytime you go into this function, if it executes once when you have a new breath
     MinContributionNew = MinContributionCount * VelContribution; // So this increases by 0.2f everytime this function is called
    }


    public void LuzDown()
    {

        lerpedValue = Mathf.Lerp(currentValue, targetValueDown, Time.deltaTime * lerpSpeedDown);

        rend.material.SetFloat("_ZeroValue", Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution));

        currentValue = rend.material.GetFloat("_ZeroValue");
    }

}
