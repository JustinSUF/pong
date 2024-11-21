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
    public bool gameOver = false; // Flag to indicate if the game is over

    // References to the Canvas parts
    public GameObject endCanvas; // Assign in the Inspector
    public GameObject blueCanvas; // Assign in the Inspector
    public GameObject redCanvas; // Assign in the Inspector

    void Start()
    {
        UpdateScoreUI();
        // Make sure the canvas parts are initially disabled
        endCanvas.SetActive(false);
        blueCanvas.SetActive(false);
        redCanvas.SetActive(false);
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
        CheckForWinner();
    }

    private void UpdateScoreUI()
    {
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();
    }

    private void CheckForWinner()
    {
        if (score1 >= 11)
        {
            endCanvas.SetActive(true);
            redCanvas.SetActive(true);
            gameOver = true;
        }
        else if (score2 >= 11)
        {
            endCanvas.SetActive(true);
            blueCanvas.SetActive(true);
            gameOver = true;
        }
    }
}
