using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private int score;
    [SerializeField] private ScoreUI scoreUI;

    private void Awake()
    {
        Instance = this;
        scoreUI.SetScoreTextValue("Score: " + score.ToString() + " pts.");
    }

    public void IncreaseScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreUI.SetScoreTextValue("Score: " + score.ToString() + " pts.");
    
    }

}
