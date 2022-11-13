using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int turnSpeed;

    public GameObject gameManager;
    //public GameObject gameManagerScript;

    float h, v;

    void Start()
    {
        
    }

 
    void Update()
    {
        InputPlayer();
        Movement();
        Rotate();
    }

    void InputPlayer()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void Movement()
    {
        transform.Translate(Vector3.forward * speed * v * Time.deltaTime);
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * turnSpeed * h * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ManaCoin"))
        {
            //To access GameManager to get AddCoin method
            gameManager.GetComponent<GameManager>().AddCoin();
            //gameManagerScript.AddCoin();

            Destroy(other.gameObject);
        }
    }
}

