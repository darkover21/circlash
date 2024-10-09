using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;

 
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
                    Debug.Log("Trajectory: " + (endPos - startPos).normalized);
                    break;
                
            }
         }
    }
   

}
