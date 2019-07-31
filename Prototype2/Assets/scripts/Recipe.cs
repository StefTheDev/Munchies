using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum FoodType
{
    APPLE,
    ORANGE,
    CHIPS
};

public class Recipe : MonoBehaviour
{

    private Image[] images;
    private List<Image> foods;

    public Recipe Initialise(int size)
    {
        this.foods = new List<Image>();
        this.images = Resources.LoadAll<Image>("Food");

        for(int i = 0; i < size; i++)
        {
            foreach(Image image in images)
            {
                if (image.name.ToUpper() == RandomFood().ToString().ToUpper())
                {
                    foods.Add(Instantiate(image, transform, false));
                }
            }
        }
        return this;
    }

    private FoodType RandomFood()
    {
        return (FoodType)UnityEngine.Random.Range(0, 3);
    }
}
