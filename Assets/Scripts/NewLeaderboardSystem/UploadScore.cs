using Dan.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadScore : MonoBehaviour
{
    private string _publicLeaderboardKey = "5eb833f18e32de9495e650346d7bf3c55bbab10d8d08442c25bf630221d230a5";
    private List<string> _anonNicknames = new List<string>()
    {
        "Frog","Toad","Duck","Pigion","Fish","Crow","Cat","Dog","Blob"
    };
    private void Awake()
    {
        
    }
    private void Start()
    {
        
        EventManager.Instance.OnGameFinished += SetLeaderboard;
        EventManager.Instance.OnGameFinished += PersonalBest;
    }
    public void SetLeaderboard()
    {
        int score = (int)(GameManager.Instance.Stopwatch * 100);

        
        var randomNickname = _anonNicknames[Random.Range(0, _anonNicknames.Count)] + $"{Random.Range(1, 500)}";
        LeaderboardCreator.UploadNewEntry(_publicLeaderboardKey, randomNickname, score, (message) =>
        {
            print("successfully uploaded");
        });
    }

    private void PersonalBest()
    {
        if (!PlayerPrefs.HasKey("PersonalBest"))
        {
            PlayerPrefs.SetFloat("PersonalBest", 0f);
        }
        if(PlayerPrefs.GetFloat("PersonalBest") < GameManager.Instance.Stopwatch)
        {
            PlayerPrefs.SetFloat("PersonalBest", GameManager.Instance.Stopwatch);
            print("Saved PB");
            PlayerPrefs.Save();
        }
        else
        {
            return;
        }
            

    }
    private void OnDisable()
    {
        EventManager.Instance.OnGameFinished -= SetLeaderboard;
    }
}
