using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class MainLeaderBoard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardkey = "afafebcb69061d943c90bd6e167d9a12e6bc4cae4fefa22eb450281a7284aea6";

    public void getLeaderBoard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardkey, ((msg) => 
        { 
            for(int i = 0; i < names.Count; i++) 
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username,int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardkey,username, score, ((msg) => 
        {
            getLeaderBoard();
        }));
    }
}
