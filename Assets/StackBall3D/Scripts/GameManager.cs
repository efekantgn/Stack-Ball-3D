using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        WaitingForStart = 0,
        Started = 1,
        Paused = 2,
        Ended = 3
    }
    public State GameState = State.WaitingForStart;
    public Action OnGameStarted;
    public Action OnGameEnded;
    public static GameManager instance;

    public GameObject InGameUI;
    public GameObject EndGameUI;


    private void Awake()
    {
        if (instance != null) Destroy(this.gameObject);

        instance = this;
    }

    private void Start()
    {
        OnGameEnded += EndGame;
        OnGameStarted += StartGame;
    }

    private void StartGame()
    {
        GameState = State.Started;
    }

    private void EndGame()
    {
        GameState = State.Ended;
        EndGameUI.SetActive(true);
        InGameUI.SetActive(false);
    }

    private void Update()
    {
        if (GameState == State.WaitingForStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameState = State.Started;
                OnGameStarted?.Invoke();
            }
        }
    }
    public void SetGameState(int enumValue)
    {
        GameState = (State)enumValue;
        EndGameUI.SetActive(false);
        InGameUI.SetActive(true);
    }

}
