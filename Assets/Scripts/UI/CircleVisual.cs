using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CircleVisual : MonoBehaviour
{
    [SerializeField] private SpriteRenderer circleSprite;
    [SerializeField] private float radius = 0.5f;
    [SerializeField] private TextMeshProUGUI circleText;
  

    public void SetColor(Color color)
    {
        circleSprite.color = color;
    }

    public void SetRadius(int radiusScale)
    {
        transform.parent.transform.localScale = Vector3.one * (radius + 0.1f * radiusScale);
    }

    public Color GetColor() 
    {
        return circleSprite.color;
    }

    public void SetTextScore(string scorePoints) 
    { 
        circleText.text = scorePoints;
    }
}
