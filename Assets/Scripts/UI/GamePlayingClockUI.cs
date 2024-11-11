using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image timerImage;
    Animator animator;
    private const string TIME_TO_END_PARAMETER = "TimeToEnd";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat(TIME_TO_END_PARAMETER, 50.0f);
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        float time = GameManager.Instance.GetGamePlayingTimerNormalized();
        timerImage.fillAmount = time;
        animator.SetFloat(TIME_TO_END_PARAMETER, GameManager.Instance.GetGamePlayingTimerToEnd());

       // Debug.Log(GameManager.Instance.GetGamePlayingTimerToEnd());


    }
}
