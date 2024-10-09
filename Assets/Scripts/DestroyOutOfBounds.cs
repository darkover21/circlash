using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xMaxScreenLimit = 2.8f;
    private float yMaxScreenLimit = 5.0f;
    void Update()
    {
        if(transform.position.x > xMaxScreenLimit || transform.position.x < -xMaxScreenLimit)
            Destroy(gameObject);

        if (transform.position.y > yMaxScreenLimit || transform.position.y < -yMaxScreenLimit) 
            Destroy(gameObject);
    }
}
