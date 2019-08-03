using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Unhealthy food types must be all at the bottom (The top of FoodType & HealthyFoodType must be the same)
public enum FoodType
{
    APPLE,
    ORANGE,
    CHIPS
};

public enum HealthyFoodType
{
    APPLE,
    ORANGE
};

public class Recipe : MonoBehaviour
{
    private Image[] images;
    public Stack<Image> foodImages;
    public Stack<HealthyFoodType> recipeFood;
    private int completionScore, numHealthyFoods;

    private void Awake()
    {
        numHealthyFoods = System.Enum.GetValues(typeof(HealthyFoodType)).Length;
    }

    public Recipe Initialise(int size)
    {
        this.foodImages = new Stack<Image>();
        this.recipeFood = new Stack<HealthyFoodType>();
        this.images = Resources.LoadAll<Image>("Food");

        for(int i = 0; i < size; i++)
        {
            var randomFood = RandomFood();

            foreach (Image image in images)
            {
                if (image.name.ToUpper() == randomFood.ToString().ToUpper())
                {
                    foodImages.Push(Instantiate(image, transform, false));
                    recipeFood.Push(randomFood);
                    break;
                }
            }
        }

        completionScore = RecipeManager.foodScore * size;

        return this;
    }
    
    public bool IsFinished()
    {
        return foodImages.Count <= 0;
    }

    public bool IsNotMatching(Image image)
    {
        Image currentImage = foodImages.Peek();

        if(currentImage == image)
        {
            foodImages.Pop();
            return false;
        }
        else
        {
            foodImages.Clear();
            return true;
        }
    }
    
    private HealthyFoodType RandomFood()
    {
        return (HealthyFoodType)UnityEngine.Random.Range(0, numHealthyFoods);
    }

    // Move to the next item in the recipe
    public void AdvanceRecipe()
    {
        if (recipeFood.Count > 0)
        {
            recipeFood.Pop();
            foodImages.Pop();
        }
    }

    public HealthyFoodType GetNextFood()
    {
        return recipeFood.Peek();
    }

    public int GetSize()
    {
        return recipeFood.Count;
    }

    public void Completed()
    {
        GameManager.Instance.AddScore(completionScore);
    }
}
