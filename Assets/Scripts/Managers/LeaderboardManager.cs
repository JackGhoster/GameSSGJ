using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class LeaderboardManager : MonoBehaviour
{
    private int _leaderboardID = 13693;
    public static LeaderboardManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SubmitScoreRoutine(int scoreToUpload)
    {
        string playerId = PlayerPrefs.GetString("PlayerId");
#pragma warning disable CS0618 // Type or member is obsolete
        LootLockerSDKManager.SubmitScore(playerId, scoreToUpload, _leaderboardID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully uploaded score");
            }
            else
            {
                Debug.Log($"Failed, because of {response.Error}");
            }
        });
#pragma warning restore CS0618 // Type or member is obsolete
    }
}
