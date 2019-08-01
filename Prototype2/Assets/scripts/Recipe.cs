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
    public List<Image> foodImages;
    public List<HealthyFoodType> recipeFood;
    private int completionScore;
    private int numHealthyFoods;

    private void Awake()
    {
        numHealthyFoods = System.Enum.GetValues(typeof(HealthyFoodType)).Length;
    }

    public Recipe Initialise(int size)
    {
        this.foodImages = new List<Image>();
        this.images = Resources.LoadAll<Image>("Food");

        for(int i = 0; i < size; i++)
        {
            var randomFood = RandomFood();

            foreach (Image image in images)
            {
                if (image.name.ToUpper() == randomFood.ToString().ToUpper())
                {
                    foodImages.Add(Instantiate(image, transform, false));
                    recipeFood.Add(randomFood);
                    break;
                }
            }
        }

        completionScore = RecipeManager.foodScore * size;

        return this;
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
            recipeFood.RemoveAt(0);
            foodImages.RemoveAt(0);

            if (recipeFood.Count == 0)
            {
                GameManager.Instance.AddScore(completionScore);
            }
        } 
    }

    public HealthyFoodType GetNextFood()
    {
        return recipeFood[0];
    }

    public int GetSize()
    {
        return recipeFood.Count;
    }
}
