using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private const string TUTORIAL_DONE = "IsTutorialDone";

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            if (PlayerPrefs.HasKey(TUTORIAL_DONE))
            {
                // Click
                Loader.Load(Loader.Scene.MainScene);
            }
            else 
            {
                PlayerPrefs.SetString(TUTORIAL_DONE, "done");
                PlayerPrefs.Save();

                // Click
                Loader.Load(Loader.Scene.TutorialScene);
            }
            
        });

        exitButton.onClick.AddListener(() =>
        {
            // Click
            Application.Quit();
        });
    }
}
