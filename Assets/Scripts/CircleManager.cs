using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        timeToInstantiate -= Time.deltaTime;
        if (timeToInstantiate < 0f) 
        {

            timeToInstantiate = timeToInstantiateMax;
            Transform circleTransform = Instantiate(circlePrefab,GetRandomPosition(),circlePrefab.rotation,transform);
            circleTransform.GetComponent<Circle>().SetColor(colorsArray[Random.Range(0, colorsArray.Length)]);
            circleTransform.gameObject.SetActive(true);

            

        }
    }

    private Vector3 GetRandomPosition() 
    {
        return new Vector3(Random.Range(-xMaxScreenLimit, xMaxScreenLimit), 
            Random.Range(-yMaxScreenLimit, yMaxScreenLimit), 0f);
    }

}
