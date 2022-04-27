using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindBreathProxy : MonoBehaviour
{
    [Header("Dependencies")]
    public FlowManager manager;
    public VientoOK viento;
    public PechoOK2 distorsion;
    public PDSensor pdScript;
    //public AudioSource audioA;
   // public AudioSource audioB;
    //public bool play01 = false;

    private float newValueAnt = 0;

    public int lastBreathValue = MyMessageListener.CHEST_EXHALE;/////////////////////////////////////////////////////////
    private FlowManager flow;//funiona?? SIII

    private bool CanAnimate => !distorsion.IsAnimating && !viento.IsAnimating;////////////////////////////////////////////////

    private bool isWaitingForFirstInhale = true;

    [Header("Debug")]
    public bool exitOnFinish;//PONERLO EN TRUE?
    [Header("State")]
    public int steps;

    private void OnEnable()
    {
        FindObjectOfType<MyMessageListener>().OnChestValueReceived += UpdateValue;
    }

    private void OnDisable()
    {
        FindObjectOfType<MyMessageListener>().OnChestValueReceived -= UpdateValue;
    }

    private void Start()
    {
        flow = FindObjectOfType<FlowManager>();
        flow.OnStateChanged += (currentState, previousState) =>
        {
            if (previousState == GameState.Chest)
            {
                enabled = false;
                return;
            }

            if (currentState == GameState.Chest)
            {
                enabled = true;
                return;
            }
        };
    }

    private void UpdateValue(int newValue)
    {
        if (isWaitingForFirstInhale && newValue == MyMessageListener.CHEST_INHALE)///////////////
        {
            isWaitingForFirstInhale = false;
            distorsion.PlayFirstBreathAnimation();
        }

        //Debug.Log($"isValueOK = {newValue == lastBreathValue}\nCanAnimate = {CanAnimate}", this);
        ////Debug.Log($"Is distortion animating = {distorsion.IsAnimating}\nIs wind animatig = {viento.IsAnimating}", this);

        if (newValue == lastBreathValue || !CanAnimate || isWaitingForFirstInhale) return;  // CanAnimate es shader

        lastBreathValue = newValue;

        //PECHO//////////////////////////////////////////////////////////////////////////////////PECHO
        if (newValue == MyMessageListener.CHEST_INHALE && !SoundManager.instance.IsPlaying)//(L2 == 2 && L2 != L2) //(newValue >= 3 && !SoundManager.instance.IsPlaying) // 
        {
            Debug.Log("pechoWindProxy");
            //steps++;

            //distorsion.AnimateToNextState();
            ////viento.Animate(true);

            //print(steps);
            //if (steps == 1)
            //{
            //    SoundManager.instance.PlayInstruccion01();
            //    //play01 = true;
            //    //Debug.Log("true");
            //}


            //else if (steps == 2)
            //{
            //    SoundManager.instance.PlayInstruccion02();//CHEST

            //}
            //else if (steps == 3)
            //{
            //    SoundManager.instance.PlayInstruccion033();//POESIA
            //    pdScript.increaseUp();
            //}
            //else if (steps == 4)
            //{
            //    SoundManager.instance.PlayInstruccion03();//BELLY01
            //    Debug.Log("belly1");

            //    if (exitOnFinish)
            //    {
            //        flow.SetState(GameState.Belly);
            //    }
            //}

        }

        //if (play01 == true && !SoundManager.instance.IsPlaying && newValue <= 3)///AUDIO B para separar instruccion??
        //{
        //    //audioB.PlayScheduled(AudioSettings.dspTime + 5);
        //    audioB.PlayDelayed(10);
        //    Debug.Log("playB");

        //}

        else if (newValue == MyMessageListener.CHEST_EXHALE)
        {
            //viento.Animate(false);
        }


    }

    
}
