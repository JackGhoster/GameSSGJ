using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdateScore();
            EventManager.Instance.GameFinished();
        }
    }

    private void UpdateScore()
    {
        var score = (int) (GameManager.Instance.Stopwatch * 1000);
        
        LeaderboardManager.Instance.SubmitScoreRoutine(score);
    }
}
