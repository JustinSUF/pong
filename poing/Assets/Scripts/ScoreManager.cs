using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText1; // Assign in the Inspector
    public TMP_Text scoreText2; // Assign in the Inspector
    private int score1 = 0;
    private int score2 = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(string goalTag)
    {
        if (goalTag == "Goal1")
        {
            score1++;
        }
        else if (goalTag == "Goal2")
        {
            score2++;
        }
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();
    }
}

