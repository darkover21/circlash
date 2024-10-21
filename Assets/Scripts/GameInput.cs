using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameInput : MonoBehaviour
{
    
    public static GameInput Instance {  get; private set; }


    public event EventHandler OnPauseAction;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 trajectory;
    [SerializeField] private Button onPauseButton;

    private Circle circleSelected = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        onPauseButton.onClick.AddListener(() => 
        OnPauseAction?.Invoke(this, EventArgs.Empty));
    }

    private void Update()
    {
         if (Input.touchCount > 0 )
         {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                   
                    break;
                case TouchPhase.Moved:
                    
                    break;
                case TouchPhase.Ended:
                    endPos = touch.position;
                    trajectory = (endPos - startPos).normalized;
                    if (circleSelected != null) 
                    {
                        circleSelected.SetNewTrajectory(trajectory);
                        //circleSelected.SetColor(Color.cyan);
                        circleSelected = null;
                        SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipRefsSO.pushEffect[2], Camera.main.transform.position, 0.3f);
                        //Debug.Log("Trajectory: " + (endPos - startPos).normalized);
                    }
                   
                    break;
                
            }
         }
    }

    public void SetCircleSelected(Circle circle)
    { 
        circleSelected = circle;
    }
}
