using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState1 { NotStarted1, Chest1, Belly1, Pulse1 }

public class FlowCal : MonoBehaviour
{
    public GameState1 CurrentState1;
    public GameState1 PreviousState1;

    public event Action<GameState1, GameState1> OnStateChanged;

    //public void Awake()//NO FUNCIONA
    //{
    //    SetState(GameState1.NotStarted1);
    //}

    public void SetState(GameState1 newState1)
    {
        if (newState1 == CurrentState1) return;

        PreviousState1 = CurrentState1;
        CurrentState1 = newState1;

        OnStateChanged?.Invoke(CurrentState1, PreviousState1);
    }
}
