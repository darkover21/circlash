using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { private set; get; }
    [SerializeField] private int score;
    [SerializeField] private ScoreUI scoreUI;
    private const string RECORD_SCORE = "recordScore";

    private void Awake()
    {
        Instance = this;
        scoreUI.SetScoreTextValue(score.ToString());
    }

    public void IncreaseScore(int scoreToAdd) 
    {
        score += scoreToAdd;
        scoreUI.SetScoreTextValue("Score: " + score.ToString() + " pts.");
    
    }

    public int GetScore() 
    { 
        return score;
    }

    public int GetRecordScore() 
    {
        if (PlayerPrefs.HasKey(RECORD_SCORE))
        {
            int recordScore = PlayerPrefs.GetInt(RECORD_SCORE);
            recordScore = Mathf.Max(recordScore, score);
            PlayerPrefs.SetInt(RECORD_SCORE, recordScore);
            PlayerPrefs.Save();
            return recordScore;
        }
        else 
        {
            PlayerPrefs.SetInt(RECORD_SCORE, score);
            PlayerPrefs.Save();
            return score;
        }
    }
}
