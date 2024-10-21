using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] protected TextMeshProUGUI recordScoreText;

    private const string MAIN_SCENE_NAME = "MainScene";

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        Hide();

        reloadButton.onClick.AddListener(() => Loader.Load(Loader.Scene.MainScene));
        exitButton.onClick.AddListener(() => Loader.Load(Loader.Scene.MenuScene));


    }

    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGameOverActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void SetScoreTextsValue()
    {
        finalScoreText.text = "Score results: " + ScoreManager.Instance.GetScore().ToString() + " pts.";
        recordScoreText.text = "Record score: " + ScoreManager.Instance.GetRecordScore() + " pts.";
    }

    private void Show()
    {
        SetScoreTextsValue();
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
