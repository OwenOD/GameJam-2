using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollow : MonoBehaviour
{

    [SerializeField] float speed = 10.0f;

    [SerializeField] Transform target;

    Vector3 offset;

	void Awake()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {         
        transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.fixedDeltaTime);

        //if (Vector3.Distance(transform.position, target.position + offset))
        //{

        //}
	}
}
