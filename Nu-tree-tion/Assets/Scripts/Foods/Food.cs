using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FoodType
{
    APPLE,
    ORANGE,
    BANANA,
    WATERMELON,
    ROTTEN_APPLE,
    ROTTEN_BANANA
}

public class Food : MonoBehaviour
{
    public bool isHealthy = true;
    public int movePosition;
    public FoodType type;
    public Sprite sprite;

    public Food()
    {
        movePosition = 0;
    }
}
