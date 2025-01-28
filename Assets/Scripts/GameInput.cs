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
    [SerializeField] private CirclePointer circlePointer;

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

            Vector3 screenPosition = touch.position;

            // Convierte a coordenadas del mundo.
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));
            circlePointer.SetCirclePointerEnabled(circleSelected != null);
            circlePointer.transform.position = worldPosition;
            if (circleSelected != null)
                circlePointer.SetLineRenderer(circleSelected.transform, circlePointer.transform);
            Debug.Log(worldPosition);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    
                   
                    break;
                case TouchPhase.Moved:
                    
                    break;
                case TouchPhase.Ended:
                    
                    endPos = Camera.main.ScreenToWorldPoint(touch.position);
                   
                    if (circleSelected != null) 
                    {
                        
                        //Debug.Log(speed);
                        startPos = circleSelected.transform.position;
                        trajectory = (endPos - startPos);
                        float speed = Mathf.Sqrt(trajectory.magnitude);
                        circleSelected.SetNewSpeedValue(speed);
                        circleSelected.SetNewTrajectory(trajectory);
                        circleSelected.SetCircleSelected(false);
                        circleSelected = null;
                        SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipRefsSO.pushEffect[2], Camera.main.transform.position, 0.3f);
                        circlePointer.SetCirclePointerEnabled(false);
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
