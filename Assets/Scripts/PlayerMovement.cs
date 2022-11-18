using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public int turnSpeed;

    float h, v;

    //This variable stores the direction of movement
    Vector3 movement;
    Rigidbody rb;
    Animator anim;

    public GameObject gameManager;
    //public GameObject gameManagerScript;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        InputPlayer();
        //MovementTransform();
        //Rotate();
        Animating();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputPlayer()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        movement = new Vector3(h, 0, v);
        //To avoid the problem that it goes faster diagonally we have to normalize.
        movement.Normalize();
    }

    void Move()
    {
        rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
    }

    void MovementTransform()
    {
        /*Don't forget this:
        * 
        * Vector3.forward = (0,0,1)
        * Vector3.right = (1,0,0)
        * 
        * movement = (0,0,1) - Teclas WS
        * movement = (1,0,0) - Teclas AD
        * movement = (1,0,1) - Teclas WD
        * 
        * transform.Translate(Vector3.forward * speed * v * Time.deltaTime);
        * transform.Translate(Vector3.right * speed * h * Time.deltaTime);
        * 
        * But we can do this in one line y we can eliminate the method Rotate too
        */
        transform.Translate(movement * speed * Time.deltaTime);

    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * turnSpeed * h * Time.deltaTime);
    }

    void Animating()
    {
        //If input horizontal or vertical are different to zero
        if(h !=0 || v !=0)
        {
            //Then player is moving and this condition is true and the animation runs
            anim.SetBool("IsMoving", true);
        }
        else
        {
            //Then player is not moving and this condition is false and the animation doesn't runs
            anim.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ManaCoin"))
        {
            /*To access GameManager to get AddCoin method
             gameManager is a variable of Gameobject type*/
            gameManager.GetComponent<GameManager>().AddCoin();

            /*gameManagerScript is a variable GameManager type
            gameManagerScript.AddCoin();*/
           

            Destroy(other.gameObject);
        }
    }
}

