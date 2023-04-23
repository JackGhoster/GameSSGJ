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
    }

    private void RestartMinigame()
    {
        if(Instance.Hiding == true)
        {
            Instantiate(_minigame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
