using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //player should spawn above the ground
    public bool isGrounded = false;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment")
        {
            isGrounded = true;
        }
    }
    private void OnMouseDown()
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
        isGrounded = false;
    }
    public void Rotate()
    {
        Debug.Log("WEEEEEEE!");
    }
}
