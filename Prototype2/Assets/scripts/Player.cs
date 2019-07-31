using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceFromCenter = 1.0f;

    private Vector3 initialPosition;

    // The most recent directional key pressed by the player determines their position
    Vector3 movePosition;

    enum KeyType
    {
        UP = 0,
        DOWN,
        LEFT,
        RIGHT
    }

    private bool[] keys;

    private void Awake()
    {
        initialPosition = this.transform.position;
        keys = new bool[4];
    }

    private void Update()
    {
        UpdateKeys();

    }

    private void FixedUpdate()
    {
        this.transform.position = initialPosition + (movePosition * distanceFromCenter);
        this.transform.rotation = Quaternion.Euler(0.0f, Vector3.SignedAngle(Vector3.forward, movePosition, Vector3.up), 0.0f);
    }

    private void UpdateKeys()
    {
        // Change movePosition
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            keys[(int)KeyType.UP] = true;
            movePosition = Vector3.forward;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            keys[(int)KeyType.UP] = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            keys[(int)KeyType.DOWN] = true;
            movePosition = Vector3.back;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            keys[(int)KeyType.DOWN] = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            keys[(int)KeyType.LEFT] = true;
            movePosition = Vector3.left;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            keys[(int)KeyType.LEFT] = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            keys[(int)KeyType.RIGHT] = true;
            movePosition = Vector3.right;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            keys[(int)KeyType.RIGHT] = false;
        }

        if (!keys[(int)KeyType.RIGHT] && !keys[(int)KeyType.LEFT] && !keys[(int)KeyType.UP] && !keys[(int)KeyType.DOWN])
        {
            movePosition = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var food = other.GetComponent<Food>();

        // If we are colliding with a food object
        if (food)
        {
            Debug.Log("Ate food. IsGood = " + food.isGood);
            Destroy(food.gameObject);
        }
    }
}
