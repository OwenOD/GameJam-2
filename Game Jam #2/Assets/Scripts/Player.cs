using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float startSpeed = 0.1f;
    private float speed;
    public float boing;

    //player should spawn above the ground
    public bool isGrounded = false;

    Rigidbody rb;

    public void Start()
    {
        speed = startSpeed;
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        //need to adjust
        boing = rb.velocity.z;

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
            rb.velocity -= new Vector3 (0,0,speed);
        }
        if (!isGrounded)
        {
            rb.velocity += new Vector3(0, 0, speed / 3);
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
