using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isHealthy = true;
    public int movePosition;
    public FoodType type;

    public Food()
    {
        movePosition = 0;
    }
}
