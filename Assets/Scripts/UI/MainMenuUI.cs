using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            // Click
            Loader.Load(Loader.Scene.MainScene);
        });

        exitButton.onClick.AddListener(() =>
        {
            // Click
            Application.Quit();
        });
    }
}
