using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTMP;
    [SerializeField] private TextMeshProUGUI endScoreTMP;
    [SerializeField] private TextMeshProUGUI usernameTMP;
    [SerializeField] private UserData userDataSO;
    private int SurviveTime;
    [SerializeField] private Leaderboard leaderboard;


    public void Start()
    {
        GameManager.instance.OnGameStarted += GameStarted;
        GameManager.instance.OnGameEnded += GameEnded;
    }

    private void GameEnded()
    {
        endScoreTMP.text = SurviveTime.ToString();
        leaderboard.SetLeaderboardEntry(userDataSO.Username, int.Parse(endScoreTMP.text));
    }

    private void GameStarted()
    {
        scoreTMP.text = "";
        StartCoroutine(nameof(IncreaseTimer));
        UpdateSurviveTime(0);
    }

    private IEnumerator IncreaseTimer()
    {
        while (GameManager.instance.GameState == GameManager.State.Started)
        {
            yield return new WaitForSeconds(1f);
            UpdateSurviveTime(SurviveTime + 1);
        }

    }
    public void UpdateSurviveTime(int surviveTime)
    {
        SurviveTime = surviveTime;
        scoreTMP.text = SurviveTime.ToString();
    }
}
