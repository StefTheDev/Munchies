using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class ConveyorPusher : MonoBehaviour
{
    public enum PushDirection
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public PushDirection pushDirection;
    public float pushForce = 1.0f;
    private Vector3 pushVector;

    private void Awake()
    {
        switch(pushDirection)
        {
            case PushDirection.UP:
                {
                    pushVector = Vector3.forward;
                    break;
                }

            case PushDirection.DOWN:
                {
                    pushVector = Vector3.back;
                    break;
                }

            case PushDirection.LEFT:
                {
                    pushVector = Vector3.left;
                    break;
                }

            case PushDirection.RIGHT:
                {
                    pushVector = Vector3.right;
                    break;
                }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var food = other.GetComponent<Food>();

        if (food)
        {
            Rigidbody body = other.GetComponent<Rigidbody>();

            body.AddForce(pushVector * pushForce);
        }
    }
}
