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
    public List<HealthyFoodType> recipeFood;
    private int completionScore, numHealthyFoods;

    private void Awake()
    {
        numHealthyFoods = System.Enum.GetValues(typeof(HealthyFoodType)).Length;
    }

    public Recipe Initialise(int size)
    {
        this.foodImages = new Stack<Image>();
        this.images = Resources.LoadAll<Image>("Food");

        for(int i = 0; i < size; i++)
        {
            var randomFood = RandomFood();

            foreach (Image image in images)
            {
                if (image.name.ToUpper() == randomFood.ToString().ToUpper())
                {
                    foodImages.Push(Instantiate(image, transform, false));
                    recipeFood.Add(randomFood);
                    break;
                }
            }
        }

        completionScore = RecipeManager.foodScore * size;

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
    
    private HealthyFoodType RandomFood()
    {
        return (HealthyFoodType)UnityEngine.Random.Range(0, numHealthyFoods);
    }

    // Move to the next item in the recipe
    public void AdvanceRecipe()
    {
        if(recipeFood.Count > 0)
        {
          recipeFood.RemoveAt(0);
          foodImages.Pop();
          if (recipeFood.Count == 0)
          {
                GameManager.Instance.AddScore(completionScore);
          }
        }
    }

    //Make this a stack
    public HealthyFoodType GetNextFood()
    {
        return recipeFood[0];
    }

    public int GetSize()
    {
        return recipeFood.Count;
    }
}
