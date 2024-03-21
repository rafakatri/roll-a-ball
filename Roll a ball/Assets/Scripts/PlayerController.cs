using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Rendering.Universal;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public EnemyController enemyController;
    private Transform tr;
    private int count;
    private int score;
    private float movementX;
    private float movementY;
    private float targetTime = 30.0f;
    private GameObject[] pickUps;
    private int numPickUps = 6;
    private int numEnemy = 1;
    public float speed;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject loseTextObject;
    public GameObject backObject;
    public TextMeshProUGUI TimerObject;
    public AudioSource pickUpFX;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        tr = GetComponent <Transform>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        backObject.SetActive(false);
        SummonPickUps(numPickUps);
        pickUps = GameObject.FindGameObjectsWithTag("PickUp");
    }

    void Update()
    {
        if (targetTime > 0)
        {
            targetTime -= Time.deltaTime;
            TimerObject.text =  "Time: " + ((int) targetTime).ToString();

            if (tr.position.y < -2) 
            {
                FinishGame();
            }
        }

        else
        {
            FinishGame(); 
        }
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y;
    }

    void SetCountText() 
   {
       countText.text =  "Score: " + score.ToString();
   }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
       {
           pickUpFX.Play();
           Destroy(other.gameObject);
           score += 1;
           count += 1;
           SetCountText();
       }

       if (count == numPickUps)
       {
            targetTime = 30.0f;
            count = 0;
            foreach(GameObject g in pickUps) 
            {
                Destroy(g);
            }
            numPickUps += 1;
            SummonPickUps(numPickUps);
            enemyController.SummonEnemy(numEnemy);
            pickUps = GameObject.FindGameObjectsWithTag("PickUp");
       }
    }

    void SummonPickUps(int n) 
    {
        for (int i = 0; i < n; i++){
            var position = new Vector3(UnityEngine.Random.Range(-11.5f, 11.5f), 0.5f, UnityEngine.Random.Range(-11.5f, 11.5f));
            Instantiate(prefab, position, Quaternion.identity);
        }
    }

    void FinishGame()
    {
        loseTextObject.SetActive(true);
        backObject.SetActive(true);

        foreach(GameObject g in pickUps) 
        {
            Destroy(g);
        }
    }

}
