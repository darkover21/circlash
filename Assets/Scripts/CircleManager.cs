using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleManager : MonoBehaviour
{
    enum ScreenStartPos 
    { 
        Top,
        Left,
        Right,
        Bottom
    }

    [SerializeField] private Transform circlePrefab;
    [SerializeField] private float timeToInstantiateMax = 10.0f;
    private float xMaxScreenLimit= 2.8f;
    private float yMaxScreenLimit = 5.0f;
    private float timeToInstantiate;
    private Color[] colorsArray = { Color.red, Color.green, Color.blue, Color.grey };

    private void Awake()
    {
        circlePrefab.gameObject.SetActive(false);
        timeToInstantiate = timeToInstantiateMax;
    }

    private void Update()
    {
        if (!GameManager.Instance.IsGamePlaying()) return;

        timeToInstantiate -= Time.deltaTime;
        if (timeToInstantiate < 0f) 
        {

            timeToInstantiate = timeToInstantiateMax;
            Transform circleTransform = Instantiate(circlePrefab, GetRandomPositionOnTheSides(), circlePrefab.rotation,transform);
            circleTransform.GetComponent<Circle>().SetColor(colorsArray[Random.Range(0, colorsArray.Length)]);
            circleTransform.gameObject.SetActive(true);

            Vector2 posOnSide = new Vector2(circleTransform.position.x, circleTransform.position.y);
            Vector3 posInside3 = GenerateRandomPositionInsideScreen();
            Vector2 posInside = new Vector2(posInside3.x, posInside3.y);

            circleTransform.GetComponent<Circle>().SetNewTrajectory(posInside - posOnSide);



        }
    }

    private Vector3 GetRandomPositionOnTheSides() 
    {
        int screenSide;
        Vector3 position = new Vector3();
        screenSide = Random.Range(0, 3);

        switch (screenSide) 
        {
            case 0:
                // Top side
                position = new Vector3(Random.Range(-xMaxScreenLimit, xMaxScreenLimit), yMaxScreenLimit, 0);
                break;
            case 1:
                // Bottom side
                position = new Vector3(Random.Range(-xMaxScreenLimit, xMaxScreenLimit), -yMaxScreenLimit, 0);
                break;
            case 2:
                // Left side
                position = new Vector3(xMaxScreenLimit, Random.Range(-yMaxScreenLimit, yMaxScreenLimit), 0);
                break;
            case 3:
                // Right side
                position = new Vector3(-xMaxScreenLimit, Random.Range(-yMaxScreenLimit, yMaxScreenLimit), 0);
                break;

        }

        return position;
    }

    private Vector3 GenerateRandomPositionInsideScreen()
    { 
        return  new Vector3(Random.Range(-xMaxScreenLimit, xMaxScreenLimit), Random.Range(-yMaxScreenLimit, yMaxScreenLimit), 0);
    }

}
