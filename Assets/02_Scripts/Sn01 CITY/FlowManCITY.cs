using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState0 { NotStarted0, Chest0, Belly0, Pulse0 }

public class FlowManCITY : MonoBehaviour
{
    public GameState0 CurrentState0;
    public GameState0 PreviousState0;

    public event Action<GameState0, GameState0> OnStateChanged;

    //public void Awake()//NO FUNCIONA
    //{
    //    SetState(GameState1.NotStarted1);
    //}

    public void SetState(GameState0 newState0) {
        if (newState0 == CurrentState0) return;

        PreviousState0 = CurrentState0;
        CurrentState0 = newState0;

        OnStateChanged?.Invoke(CurrentState0, PreviousState0);
    }
}
