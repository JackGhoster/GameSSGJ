using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timeText;
    private int _time = 3;

    private void Start()
    {
        InvokeRepeating("SubtractTime", 1, 1);
    }
    private void SubtractTime()
    {
        if(_time > 0)
        {
            _time -= 1;
        }
        else
        {
            EventManager.Instance.MinigameTimerEnded();
            CancelInvoke("SubtractTime");
        }

    }

    private void Update()
    {
        if (_timeText != null)
        {
            _timeText.text = $"{_time}s left";
        }   
    }

    private void OnDestroy()
    {
        
    }
}
