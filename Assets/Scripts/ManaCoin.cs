using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaCoin : MonoBehaviour
{
    public int turnSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * turnSpeed * Time.deltaTime);
    }
}
