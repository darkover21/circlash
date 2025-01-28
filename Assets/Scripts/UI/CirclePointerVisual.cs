using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePointerVisual : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Start()
    {
        SetPointerEnabled(false);
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    public void SetPointerEnabled(bool enable = false) 
    { 
        this.gameObject.SetActive(enable);
    }

    public void SetLineRenderer(Transform pointATransform, Transform pointBTransform) 
    {
        lineRenderer.SetPosition(0, pointATransform.position); // Primer punto
        lineRenderer.SetPosition(1, pointBTransform.position); // Segundo punto
    }


}
