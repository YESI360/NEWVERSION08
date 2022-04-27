using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSB1 : MonoBehaviour
{
    Renderer rend;
    public float stepsAmount;
    public int steps;

    public float MaxContribution;
    public float MinContribution;
    public float MinContributionNew;
  
    //public float MinValue = 0.6f;
    //public float MaxValue;

    private float currentValue;
    [Range(0, 1)] public float lerpedValue;
    //public float targetValue;
    public float targetValueUp;
    public float targetValueDown;
    public float lerpSpeedUp;
    public float lerpSpeedDown;

    bool input;

    void Start()
    {
        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_HorizonLineContribution");
        //stepsAmount = (currentValue - MinContribution) / steps;
        //MaxContribution = currentValue;
        MaxContribution = 1;
        stepsAmount = 3;
        MinContributionNew = 0;
}

    void Update()
    {
    }


    public void LuzUp()
    {
        currentValue = rend.material.GetFloat("_HorizonLineContribution");
        //targetValue = currentValue - stepsAmount;

        //while (Mathf.Abs(currentValue - targetValue) > 0.001f)//CUELGA UNITY
        //{
            lerpedValue = Mathf.Lerp(currentValue, targetValueUp, Time.deltaTime * lerpSpeedUp);

            rend.material.SetFloat("_HorizonLineContribution", Mathf.Clamp(lerpedValue, MinContribution, MaxContribution));

            currentValue = rend.material.GetFloat("_HorizonLineContribution");
        //}

        input = true;

        if (input == true)
        {
            MinContributionNew = 0.2f;
        }

        //if (MinContributionNew >= 0.3f && MinContributionNew < 0.4f)
        //{
        //    MinContributionNew = MinContributionNew2;
        //}
    }


    public void LuzDown()
    {
        //if (Input.GetKey(KeyCode.DownArrow)) //(Input.GetKeyDown("down"))
        //{
        lerpedValue = Mathf.Lerp(currentValue, targetValueDown, Time.deltaTime * lerpSpeedDown);

        rend.material.SetFloat("_HorizonLineContribution", Mathf.Clamp(lerpedValue, MinContributionNew, MaxContribution));

        currentValue = rend.material.GetFloat("_HorizonLineContribution");
        //}

        //LIMITE vuelve de golpe
        //if (currentValue > MinValue)
        //{
        //    Debug.Log("piso");
        //    //currentValue = MinValue;
        //    Mathf.Lerp(currentValue, MinValue, lerpSpeedDown * Time.deltaTime);
        //}
    }

}
