using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBlock : MonoBehaviour
{
    Enemy enemy;
    Rigidbody rb;
    [SerializeField] float thrust;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.down * thrust);
        
    }
}
