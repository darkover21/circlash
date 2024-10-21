
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Circle : MonoBehaviour, IDragHandler
{

    [SerializeField] private CircleVisual circleVisual;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private Vector2 trajectory;
    [SerializeField] private int scorePoints = 1;
    private Rigidbody2D rigidBody2D;
    private const string COLLISION_CIRCLE_TAG = "Circle";
 

   
    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }


    public void SetColor(Color color)
    {
        circleVisual.SetColor(color);
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
                SetNewSpeedValue(scorePoints);
                SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipRefsSO.crashSound, Camera.main.transform.position, 0.3f);
            }
            else
            {
                //SoundManager.Instance.PlaySound(SoundManager.Instance.audioClipRefsSO.gameOverSound, Camera.main.transform.position, 0.3f);
                Destroy(gameObject);
            }
        }
    }

    private void SetNewSpeedValue(int speedScale)
    {
        speed -= speedScale;
        rigidBody2D.velocity = trajectory * speed;
    }

    public void SetNewTrajectory(Vector2 trajectoryVector)
    {
        trajectoryVector = trajectoryVector.normalized;
        rigidBody2D.velocity = trajectoryVector * speed;
        rigidBody2D.AddForce(trajectoryVector);
        trajectory = trajectoryVector;
    }

    public Vector2 GetRandomSpeedVectorNormalized()
    {
        Vector2 speedVector = new Vector2(UnityEngine.Random.RandomRange(-1, 1), UnityEngine.Random.RandomRange(-1, 1));
        speedVector = speedVector.normalized;
        if (speedVector.magnitude == 0) speedVector = GetRandomSpeedVectorNormalized();
        return speedVector;
    }

    public void OnDrag(PointerEventData eventData)
    {
        GameInput.Instance.SetCircleSelected(this);
    }
}
