using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    public GameObject prefab;
    private GameObject[] pickUps;
    private int numPickUps = 8;

    void SummonPickUps(int n) 
    {
        for (int i = 0; i < n; i++){
            var position = new Vector3(Random.Range(-9.0f, 9.0f), 0.5f, Random.Range(-9.0f, 9.0f));
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    void Start()
    {   
        SummonPickUps(numPickUps);
    }

    void Update() 
    {
        pickUps = GameObject.FindGameObjectsWithTag("PickUp");
        if (pickUps.Length == 0)
        {
            numPickUps += 1;
            SummonPickUps(numPickUps);
        }
    }
}
