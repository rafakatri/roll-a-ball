using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private int n = 1;
    void Start()
    {
       float prob = Random.Range(0.0f,1.0f);

       if (prob < 0.5)
       {
        n *= -1; 
       }

    }

    void Update()
    {
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime * n);
    }
}
