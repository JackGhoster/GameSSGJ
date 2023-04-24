using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;


public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> _names, _scores;

    private string _publicLeaderboardKey = "5eb833f18e32de9495e650346d7bf3c55bbab10d8d08442c25bf630221d230a5";

    private void Start()
    {
        GetLeaderboard();
    }

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicKey: _publicLeaderboardKey,  (message) =>
        {
            int loopLength = (message.Length < _names.Count) ? message.Length : _names.Count;
            for(int i = 0; i < loopLength; i++)
            {
                _names[i].text = message[i].Username;
                _scores[i].text = $"{(float)(message[i].Score / 100)}s";
            }
        });
    }
}
