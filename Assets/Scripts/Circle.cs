using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Circle : MonoBehaviour
{
    [SerializeField] private CircleVisual circleVisual;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Vector2 trajectory;
    [SerializeField] private int scorePoints = 1;
    private Rigidbody2D rigidBody2D;
    private Vector2 startPos;
    private Vector2 endPos;
    private const string COLLISION_CIRCLE_TAG = "Circle";

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 speedVector = GetRandomSpeedVectorNormalized();
        rigidBody2D.velocity = speedVector * speed;
    }

    public void SetColor(Color color) 
    { 
        circleVisual.SetColor(color);
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Contains(COLLISION_CIRCLE_TAG)) 
        { 
            Circle collisionCircle = collision.gameObject.GetComponent<Circle>();
            if (collisionCircle.circleVisual.GetColor() == circleVisual.GetColor())
            {
                scorePoints++;
                ScoreManager.Instance.IncreaseScore(scorePoints);
                circleVisual.SetRadius(scorePoints);
                circleVisual.SetTextScore(scorePoints.ToString());
                trajectory = (transform.position - collision.transform.position).normalized;
                Debug.Log("Points scored: " + scorePoints);
                SetNewSpeedValue(scorePoints);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }

    private void SetNewSpeedValue(int speedScale) 
    {
        speed -= speedScale * 0.25f;
        rigidBody2D.velocity = trajectory * speed;
    }

    public void SetNewTrajectory(Vector2 trajectoryVector) 
    {
        rigidBody2D.velocity = trajectoryVector * speed;
        trajectory = trajectoryVector;
    }

    public Vector2 GetRandomSpeedVectorNormalized() 
    {
        Vector2 speedVector = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
        speedVector = speedVector.normalized;
        if (speedVector.magnitude == 0) speedVector = GetRandomSpeedVectorNormalized();
        return speedVector;
    }


}
