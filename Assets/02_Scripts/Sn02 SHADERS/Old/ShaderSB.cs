using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSB : MonoBehaviour
{
    Renderer rend;
    //public float stepAmount;
    //[Range(0, 1)] public float stepAmount;
    public float MinContribution;
    public float MaxContribution;

    public float currentValue;
    public float MaxValue;
    public float MinValue;
    private float lerpedValue;
    public float targetValueUp;
    public float targetValueDown;
    public float lerpSpeedUp;
    public float lerpSpeedDown;

    void Start()
    {
        rend = GetComponent<Renderer>();
        currentValue = rend.material.GetFloat("_HorizonLineContribution");

    }

    void Update()
    {
    }

    public void LuzDown()
    {
        //if (Input.GetKey(KeyCode.DownArrow)) //(Input.GetKeyDown("down"))
        //{
        lerpedValue = Mathf.Lerp(currentValue, targetValueDown, Time.deltaTime * lerpSpeedDown);

        rend.material.SetFloat("_HorizonLineContribution", Mathf.Clamp(lerpedValue, MinContribution, MaxContribution));

        currentValue = rend.material.GetFloat("_HorizonLineContribution");
        //}

        //if (currentValue < MinValue)
        //{
        //    currentValue = Mathf.Lerp(currentValue, MinValue, lerpSpeedDown * Time.deltaTime);
        //}

    }
    public void LuzUp()
    {
        //if (Input.GetKey(KeyCode.UpArrow)) //(Input.GetKeyDown("up"))
        //{
        lerpedValue = Mathf.Lerp(currentValue, targetValueUp, Time.deltaTime * lerpSpeedUp);

        rend.material.SetFloat("_HorizonLineContribution", Mathf.Clamp(lerpedValue, MinContribution, MaxContribution));

        currentValue = rend.material.GetFloat("_HorizonLineContribution");
        //}

        //LIMITE
        //while (currentValue < MaxValue)
        //{
        //    currentValue = Mathf.Lerp(currentValue, MaxValue, lerpSpeedUp * Time.deltaTime);
        //}
    }
}
