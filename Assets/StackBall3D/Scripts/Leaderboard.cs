using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardContentItem;
    [SerializeField] private Transform content;
    [SerializeField] private Transform localPlayer;
    [SerializeField] private UserData userData;

    private string publicLeaderboardKey = "dc37d613427a45b40c7ae5d50cd902b874a477fa67bca762c68ecc96d4023410";

    public void GetLeaderboard()
    {
        foreach (Transform child in content)
        {
            Destroy(child);
        }
        foreach (Transform child in localPlayer)
        {
            Destroy(child);
        }
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            for (int i = 0; i < msg.Length; i++)
            {
                LeaderboardContentItem tmp = Instantiate(leaderboardContentItem, content).GetComponent<LeaderboardContentItem>();
                tmp.Username = msg[i].Rank.ToString() + ". " + msg[i].Username;
                tmp.Score = msg[i].Score.ToString();
                if (msg[i].Username == userData.Username)
                {
                    userData.Score = msg[i].Score;
                    userData.Rank = msg[i].Rank;
                    InstantiateLocalPlayer(userData.Rank, userData.Username, userData.Score);
                }
            }
        }));

    }

    private void InstantiateLocalPlayer(int rank, string username, int score)
    {
        LeaderboardContentItem tmp = Instantiate(leaderboardContentItem, localPlayer).GetComponent<LeaderboardContentItem>();
        tmp.Username = rank + ". " + username;
        tmp.Score = score.ToString();
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
        {
            GetLeaderboard();
        }));
    }
}
