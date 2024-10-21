using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void SetScoreTextValue(string scoreValue)
    { 
        scoreText.text = "Score: " + scoreValue + " pts.";
    }
}
