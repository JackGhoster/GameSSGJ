using LootLocker.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private Minigame _minigame;

    public bool Hiding { get; set; }
    public float Stopwatch { get; set; }


    private float _timeBias = 0.01f;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnWonMinigame += RestartMinigame;
        EventManager.Instance.OnGameStarted += StartStopwatch;
        EventManager.Instance.OnGameFinished += StopStopwatch;
        EventManager.Instance.OnGameLost += ActivateRestartingRoutine;
        EventManager.Instance.OnGameFinished += ActivateEndingRoutine;
    }

    private void RestartMinigame()
    {
        if(Instance.Hiding == true)
        {
            Invoke("StartMinigame", 0.1f);
        }
    }

    private void StartMinigame()
    {
        Instantiate(_minigame);
    }
    
    private void StartStopwatch()
    {
        InvokeRepeating("TickStopwatch", _timeBias, _timeBias);
    }
    private void StopStopwatch()
    {
        CancelInvoke("TickStopwatch");
        print($"Time is: {Stopwatch}");
    }

    private void TickStopwatch()
    {
        Stopwatch += _timeBias;
        //print($"Time is: {Stopwatch}");
    }

    private void ActivateRestartingRoutine()
    {
        Invoke("RestartLvl",1);
    }
    private void ActivateEndingRoutine()
    {
        Invoke("LoadEnding", 3);
    }
    private void LoadEnding()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndingScene");
    }

    private void RestartLvl()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }


}
