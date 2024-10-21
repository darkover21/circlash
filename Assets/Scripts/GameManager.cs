using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPaused;

    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 4f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 30f;
    public bool isGamePaused = false;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
        state = State.WaitingToStart;

    }

    private void Start()
    {
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
        if (state == State.WaitingToStart)
        {
            state = State.CountdownToStart;
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public bool IsCountdownToStartActive()
    {
        return state == State.CountdownToStart;
    }

    public bool IsGameOverActive()
    {
        return state == State.GameOver;
    }

    public int GetCountdownToStartTimer()
    {
        return (int)countdownToStartTimer;
    }

    public float GetGamePlayingTimerNormalized()
    {
        //Debug.Log(1f - (gamePlayingTimer / gamePlayingTimerMax));
        return 1f - (gamePlayingTimer / gamePlayingTimerMax);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    public void TogglePauseGame()
    {
        isGamePaused = !isGamePaused;
        if (isGamePaused)
        {

            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {

            Time.timeScale = 1f;
            OnGameUnPaused?.Invoke(this, EventArgs.Empty);

        }

    }

    private void Update()
    {
        switch (state)
        {
            case State.WaitingToStart:
                /* waitingToStartTimer -= Time.deltaTime;
                 if (waitingToStartTimer < 0) { 
                     state = State.CountdownToStart; 
                     OnStateChanged?.Invoke(this, EventArgs.Empty);
                 }*/
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer < 0)
                {
                    gamePlayingTimer = gamePlayingTimerMax;
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0)
                {
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;

            case State.GameOver:

                break;
        }
    }
}
