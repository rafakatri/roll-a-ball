using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject prefab;
    private GameObject[] enemies;
    private GameObject player;
    private int numEnemy = 1;
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SummonEnemy(numEnemy);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject g in enemies) 
        {
           g.transform.position = Vector3.MoveTowards(g.transform.position, player.transform.position, speed * Time.deltaTime);
       	   g.transform.LookAt(player.transform.position);
        }
    }

    public void SummonEnemy(int n) 
    {
        for (int i = 0; i < n; i++){
            var position = new Vector3(Random.Range(-11.5f, 11.5f), 0.5f, Random.Range(-11.5f, 11.5f));
            Instantiate(prefab, position, Quaternion.identity);
        }

        enemies = GameObject.FindGameObjectsWithTag("enemy");

        foreach(GameObject g in enemies) 
        {
            g.GetComponent<Animator>().Play("WalkFWD");
        }
    }

}
