using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceFromCenter = 1.0f;

    private Transform initialPosition;

    // The most recent directional key pressed by the player determines their position
    Vector3 movePosition;
    

    private void Update()
    {
        // Change movePosition
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            movePosition = Vector3.forward;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            movePosition = Vector3.back;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            movePosition = Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            movePosition = Vector3.right;
        }


    }

    private void FixedUpdate()
    {
        
    }
}
