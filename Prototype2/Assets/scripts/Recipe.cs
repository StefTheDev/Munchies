using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour
{
    enum FoodType
    {
        APPLE,
    };

    public int size = 0;
    private List<FoodType> foods;

    private void Start()
    {
        foods = new List<FoodType>();
        // for(int i = 0; )
    }

    private FoodType RandomFood()
    {
        Array values = Enum.GetValues(typeof(FoodType));
        System.Random random = new System.Random();
        return (Recipe.FoodType) values.GetValue(random.Next(values.Length));
    }
}
