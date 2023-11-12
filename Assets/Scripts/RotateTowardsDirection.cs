using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChildTowardsMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] Vector3 offset = Vector3.zero; 
    private Vector3 lastChildPosition;
    private Transform childTransform;

    void Start()
    {
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(0);
            lastChildPosition = childTransform.position;
        }
    }

    void Update()
    {
        RotateChildTowardsMovementDirection();
    }

    void RotateChildTowardsMovementDirection()
    {
        if (childTransform != null)
        {
            Vector3 childMovementDirection = childTransform.position - lastChildPosition;

            if (childMovementDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(childMovementDirection, Vector3.up);
                targetRotation *= Quaternion.Euler(offset);
                childTransform.rotation = Quaternion.Slerp(childTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            lastChildPosition = childTransform.position;
        }
    }
}
