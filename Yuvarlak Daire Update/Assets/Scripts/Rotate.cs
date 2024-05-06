using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public int speed;
    void Start()
    {
        speed = Random.Range(50, 150);
    }

  
    void Update()
    {
        transform.Rotate(xAngle: 0, yAngle: 0, zAngle: speed * Time.deltaTime);
    }
}
