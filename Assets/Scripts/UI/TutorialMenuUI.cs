using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialMenuUI : MonoBehaviour
{
    [SerializeField] private Button okButton;

    private void Awake()
    {
        okButton.onClick.AddListener(() => 
            // Click
            Loader.Load(Loader.Scene.MainScene));
    }
}
