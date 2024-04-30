using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardContentItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI usernameTMP;
    [SerializeField] private TextMeshProUGUI scoreTMP;

    public string Username
    {
        set
        {
            usernameTMP.text = value;
        }
    }
    public string Score
    {
        set
        {
            scoreTMP.text = value;
        }
    }

}
