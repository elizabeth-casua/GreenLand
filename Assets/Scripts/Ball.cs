using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Class is going to be in charge of managing the ball's impulse force.
/// </summary>
public class Ball : MonoBehaviour
{
    public float force;
    public Vector3 direction;
    public float timeToDestroy = 3;
    public Material mat;

    Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            GameObject enemySlime = collision.gameObject;
            enemySlime.GetComponentInChildren<SkinnedMeshRenderer>().material = mat;
            Destroy (collision.gameObject, 0.3f);
        }
    }

    void Update()
    {
        
    }
}
