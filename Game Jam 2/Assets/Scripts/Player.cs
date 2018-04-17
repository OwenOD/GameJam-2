using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{

    [SerializeField] float startSpeed = 0.1f;

    [SerializeField] float distToGround = 0.4f;

    [SerializeField] float distToSide = 0.7f;

    [SerializeField] float jumpForce = 5;

    [SerializeField] float rotationForce = 5;

    [SerializeField] float normalDrag = 0;

    [SerializeField] float airDrag = 0.5f;


    [SerializeField] GameObject pivot;

    [SerializeField] Menu menu;

    public bool alive = true;

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
        //    return;


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

        // Move while we are grounded
        if (isGrounded)
        {
            rb.drag = normalDrag;
            rb.velocity -= new Vector3(0, 0, speed);
        }
        // Add air resistance while in the air
        if (!isGrounded)
        {
            rb.drag = airDrag;
        }

        wasMousePressed = Input.GetMouseButton(0);


    }

    void CheckIfGrounded()
    {
        isGrounded = false;

        List<Ray> rays = new List<Ray>();

        rays.Add(new Ray(transform.position, -transform.up));
        rays.Add(new Ray(transform.position + (transform.forward * distToSide), -transform.up));
        rays.Add(new Ray(transform.position + (transform.forward * -distToSide), -transform.up));

        RaycastHit hitInfo;
        foreach (var ray in rays)
        {
            if (Physics.Raycast(ray, out hitInfo, distToGround))
            {
                if (hitInfo.collider.tag == "Environment")
                {
                    isGrounded = true;
                    return;
                }
            }
        }
    }

    void Jump()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (isGrounded)
        {
            transform.position += new Vector3(0, distToGround + 0.01f, 0);

            rb.velocity = new Vector3(0, 0, rb.velocity.z); // Remove y velocity before we jump

            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);

            isGrounded = false;

            Sounds.instance.PlayJump();
        }
    }
    void Rotate()
    {
        rb.AddTorque(rotationForce, 0, 0, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment")
        {
            alive = false;
        }
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
