//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using LootLocker.Requests;
//using TMPro;

//public class LeaderboardManager : MonoBehaviour
//{
//    private int _leaderboardID = 13693;
//    public static LeaderboardManager Instance;

//    private List<string> _anonNicknames = new List<string>()
//    {
//        "Frog","Toad","Duck","Pigion","Fish","Crow","Cat","Dog","Blob"
//    };

//    private void Awake()
//    {
//        if(Instance == null)
//        {
//            Instance = this;
//        }
//    }


//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    public void SubmitScore(int scoreToUpload)
//    {
//        string playerId = PlayerPrefs.GetString("PlayerId");
//#pragma warning disable CS0618 // Type or member is obsolete
//        LootLockerSDKManager.SubmitScore(playerId, scoreToUpload, _leaderboardID, (response) =>
//        {
//            if (response.success)
//            {
//                Debug.Log("Successfully uploaded score");
//            }
//            else
//            {
//                Debug.Log($"Failed, because of {response.Error}");
//            }
//        });

//    }

//    public void FetchTopHighScores(TextMeshProUGUI playersText, TextMeshProUGUI scoresText)
//    {

//        LootLockerSDKManager.GetScoreListMain(_leaderboardID,10,0, (response) =>
//        {
//            if(response.success)
//            {
//                string tempNames = "Anon Name\n";
//                string tempScores = "Time\n";
//                LootLockerLeaderboardMember[] members = response.items;

//                for (int i = 0; i < members.Length; i++)
//                {
//                    tempNames += members[i].rank + ". ";
//                    if (members[i].player.name != "")
//                    {
//                        tempNames += members[i].player.name;
//                    }
//                    else
//                    {
//                        tempNames += _anonNicknames[Random.Range(0, _anonNicknames.Count)] + $"{Random.Range(1,500)}";
//                    }
//                    tempScores += (float)members[i].score / 1000 +"s" + "\n";
//                    tempNames += "\n";
//                    playersText.text = tempNames;   
//                    scoresText.text = $"{tempScores}";
//                }
//            }
//            else
//            {
//                Debug.Log($"Failed to fetch{response.Error}");
//            }
//        });
//    }
//}
//#pragma warning restore CS0618 // Type or member is obsolete