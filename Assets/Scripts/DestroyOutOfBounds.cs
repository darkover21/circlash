using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xMaxScreenLimit = 4.8f;
    private float yMaxScreenLimit = 7.0f;
    void Update()
    {
        if(transform.position.x > xMaxScreenLimit || transform.position.x < -xMaxScreenLimit)
            Destroy(gameObject);

        if (transform.position.y > yMaxScreenLimit || transform.position.y < -yMaxScreenLimit) 
            Destroy(gameObject);
    }
}
