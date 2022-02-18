using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rot = 0f;
    int rotSpeed = 5;

    public float forward = 0f;
    int forwardSpeed = 50;

    Rigidbody rb;

    Vector3 origPosition;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        origPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        Move();
    }
    void CheckInput()
    {
        //rotation
        rot = Input.GetAxis("Horizontal");
        //forward
        forward = Input.GetAxis("Vertical");
    }

    void Move()
    {
        //rotation
        transform.Rotate(0f, rot * rotSpeed, 0f);
        //forward
        rb.AddForce(transform.forward * forward * forwardSpeed);
    }

    public void Reset()
    {
        transform.position = origPosition;
        rb.velocity = Vector3.zero;
    }
}