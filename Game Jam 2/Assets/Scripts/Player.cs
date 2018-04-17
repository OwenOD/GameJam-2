using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float startSpeed = 0.1f;

    [SerializeField] float distToGround = 0.4f;

    [SerializeField] float distToSide = 0.7f;

    [SerializeField] float jumpForce = 5;

    [SerializeField] float rotationForce = 5;

    [SerializeField] GameObject pivot;

    [SerializeField] Menu menu;

    float speed;

    // If the player is touching the ground or not
    bool isGrounded = false;

    bool wasMousePressed = false;

    Rigidbody rb;

    public void Start()
    {
        speed = startSpeed;
        rb = GetComponent<Rigidbody>();
    }
    public void Update()
    {


        //if (menu.isPaused == false)
        {
            CheckIfGrounded();


            //need to adjust
            //jumpForce = (-rb.velocity.z / 3);

            if (Input.GetMouseButton(0))
            {
                if (wasMousePressed == false) // Initial mouse press
                {
                    Jump();
                }

                if (!isGrounded)
                {
                    Rotate();
                }
            }

            if (isGrounded)
            {
                rb.velocity -= new Vector3(0, 0, speed);
            }
            if (!isGrounded)
            {
                rb.velocity += new Vector3(0, 0, speed / 3);
            }
        }

        wasMousePressed = Input.GetMouseButton(0);
    }

    void CheckIfGrounded()
    {
        isGrounded = false;

        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distToGround))
        {
            if (hitInfo.collider.tag == "Environment")
            {
                isGrounded = true;
            }
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            transform.position += new Vector3(0, distToGround + 0.01f, 0);

            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);

            isGrounded = false;
        }
    }
    void Rotate()
    {
        rb.AddTorque(rotationForce, 0, 0, ForceMode.Acceleration);
    }

    private void OnDrawGizmos()
    {
        // Draw a line for the grounded raycast
        Gizmos.DrawLine(transform.position, transform.position + (transform.up * -distToGround));

        // Draw a line for the grounded raycast
        Gizmos.DrawLine(transform.position + (transform.forward * distToSide), transform.position + (transform.up * -distToGround) + (transform.forward * distToSide));

        // Draw a line for the grounded raycast
        Gizmos.DrawLine(transform.position + (transform.forward * -distToSide), transform.position + (transform.up * -distToGround) + (transform.forward * -distToSide));
    }
}
