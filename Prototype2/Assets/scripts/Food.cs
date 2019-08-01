using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isGood = true;
    public int movePosition;
    public FoodType type;

    public Food()
    {
        movePosition = 0;
    }
}
