using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    private static Recipe instance;

    public static Recipe Instance { get { return instance; } }

    public Sprite check;
    public RecipeFood[] recipeFoods;

    private RecipeFood[] foods;
    private int score, index;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        foods = Resources.LoadAll<RecipeFood>("Recipe");

        Refresh();
    }

    public void Refresh()
    {
        index = 0;


        for (int i = 0; i < recipeFoods.Length; i++)
        {
            RecipeFood recipeFood = recipeFoods[i];
            RecipeFood tempFood = foods[UnityEngine.Random.Range(0, foods.Length)];

            recipeFood.sprites = tempFood.sprites;
            recipeFood.name = tempFood.name;

            recipeFood.foodState = FoodState.INACTIVE;

            if (i == 0)
            {
                recipeFood.foodState = FoodState.ACTIVE;
            }
            else
            {
                recipeFood.foodState = FoodState.INACTIVE;
            }
            recipeFood.Refresh();
        }
    }

    public void Check(Food food)
    {
        if (index >= (recipeFoods.Length - 1))
        {
            ScoreManager.Instance.AddScore(100);
            GameManager.Instance.PlayRecipeComplete();
            Refresh();
            return;
        }

        RecipeFood recipeFood = recipeFoods[index];

        if (food.name.StartsWith(recipeFood.name))
        {
            GameManager.Instance.PlayCorrectIngredient();

            recipeFood.foodState = FoodState.COMPLETE;
            recipeFood.Refresh();
            index++;

            recipeFood = recipeFoods[index];
            recipeFood.foodState = FoodState.ACTIVE;
            recipeFood.Refresh();
        }
        else
        {
            Refresh();
        }
    }
}
