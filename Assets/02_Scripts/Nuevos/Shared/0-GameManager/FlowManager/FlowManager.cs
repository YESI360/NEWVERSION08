using System;
using UnityEngine;

public enum GameState { NotStarted, Chest, Belly }

public class FlowManager : MonoBehaviour
{
    public static FlowManager instance;

    public GameState CurrentState { get; private set; }
    public GameState PreviousState { get; private set; }

public event Action<GameState, GameState> OnStateChanged;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void OnLevelWasLoaded(int level) {
        CurrentState = GameState.NotStarted;
        PreviousState = GameState.NotStarted;
    }

    public void SetState(GameState newState)
    {
        if (newState == CurrentState) return;

        PreviousState = CurrentState;
        CurrentState = newState;

        OnStateChanged?.Invoke(CurrentState, PreviousState);
    }

}
