using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    
    public static GameInput Instance;



    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 trajectory;
    [SerializeField] private Circle circleSelected;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
         if (Input.touchCount > 0)
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
                        circleSelected.SetColor(Color.cyan);
                        circleSelected = null;
                    }
                    //Debug.Log("Trajectory: " + (endPos - startPos).normalized);
                    break;
                
            }
         }
    }

    public void SetCircleSelected(Circle circle)
    { 
        circleSelected = circle;
    }
}
