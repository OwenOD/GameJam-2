using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyFollow : MonoBehaviour
{

    [SerializeField] float speed = 10.0f;

    [Header("I dont think maxDistance works :/")]
    [SerializeField] float maxDistance = 0.2f;

    [SerializeField] Transform targetTransform;

    Vector3 offset;

    Quaternion rotation;


    void Awake()
    {
        offset = transform.position - targetTransform.position;

        rotation = Quaternion.Euler(targetTransform.eulerAngles.x, 0, 0);

    }

    private void FixedUpdate()
    {
        transform.rotation = targetTransform.rotation;

        Vector3 targetPos = targetTransform.position + rotation * offset;

        transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, targetPos) > maxDistance)
        {
            transform.position = targetPos;
        }
    }
}
