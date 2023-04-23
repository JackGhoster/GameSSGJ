using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopwatchUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _stopwatchText;

    // Update is called once per frame
    void Update()
    {
        _stopwatchText.text = $"Time: {System.Math.Round(GameManager.Instance.Stopwatch,3)}s";
    }
}
