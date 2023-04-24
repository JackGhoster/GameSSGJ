using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _players, _scores;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Fetch", 1);
    }

    private void Fetch()
    {
        LeaderboardManager.Instance.FetchTopHighScores(playersText: _players, scoresText: _scores);
    }
}
