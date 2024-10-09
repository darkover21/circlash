using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void SetScoreTextValue(string scoreValue) 
    { 
        scoreText.text = scoreValue;
    }
}
