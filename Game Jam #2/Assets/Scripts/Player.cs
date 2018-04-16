using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 0.1f;
    public float boing = 0.1f;

    //player should spawn above the ground
    public bool isGrounded = false;

    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (!isGrounded)
            {
                Rotate();
            }
        }
        Debug.Log("velovity is: " + rb.velocity);
        if (isGrounded)
        {
            rb.velocity += new Vector3 (speed,0,0);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment")
        {
            isGrounded = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Environment")
        {
            isGrounded = false;
        }
    }
    public void OnMouseDown()
    {
        if (isGrounded)
        {
            Jump();
        }
        else if (!isGrounded)
        {
            Rotate();
        }
    }
    public void Jump()
    {
        Debug.Log("BOING!");
        rb.velocity += new Vector3(0, boing, 0);
    }
    public void Rotate()
    {
        Debug.Log("WEEEEEEE!");
    }
}
