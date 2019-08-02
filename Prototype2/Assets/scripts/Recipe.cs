using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    public enum Food
    {
        APPLE,
        CHIPS,
        ORANGE
    };

    private Image[] images;
    private Stack<Image> foods;

    public Recipe Initialise(int size)
    {
        this.foods = new Stack<Image>();
        this.images = Resources.LoadAll<Image>("Food");

        for(int i = 0; i < size; i++)
        {
            foreach(Image image in images)
            {
                if (image.name.ToUpper() == RandomFood().ToString().ToUpper())
                {
                    foods.Push(Instantiate(image, transform, false));
                }
            }
        }
        return this;
    }

    public bool IsFinished()
    {
        return foods.Count <= 0;
    }

    public bool IsNotMatching(Image image)
    {
        Image currentImage = foods.Peek();
        if(currentImage == image)
        {
            foods.Pop();
            return false;
        }
        else
        {
            foods.Clear();
            return true;
        }
    }

    private Food RandomFood()
    {
        return (Food)UnityEngine.Random.Range(0, 3);
    }
}
