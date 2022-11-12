using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>

public class PlayerAttack : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform posBall;
    public float timeBetweenAttacks;

    float timer;

    void Start()
    {
        
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetKey(KeyCode.O) && timer >= timeBetweenAttacks)
        {
            CreateBall();
        }
    }

    void CreateBall()
    {
        timer = 0;

       GameObject cloneBallPrefab = Instantiate(ballPrefab, posBall.position, posBall.rotation);

        cloneBallPrefab.GetComponent<Ball>().direction = transform.forward;
    }
}
