using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePointer : MonoBehaviour
{
    [SerializeField] CirclePointerVisual circlePointerVisual;

    public void SetCirclePointerEnabled(bool enabled)
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        circlePointerVisual.SetPointerEnabled(enabled);
    }

    public void SetLineRenderer(Transform pointA, Transform pointB) 
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        circlePointerVisual.SetLineRenderer(pointA, pointB);
    }
}
