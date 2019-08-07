using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recipe2 : MonoBehaviour
{
    public Image spacer;

    private Food[] foods;
    private List<RecipeFood> recipeFoods;

    public void Initialise(int size)
    {
        if(foods == null) foods = Resources.LoadAll<Food>("Foods");

        for (int i = 0; i < size; i++)
        {
            Sprite sprite = Random().sprite;
            GameObject gameObject = new GameObject("Food");

            RecipeFood recipeFood = gameObject.AddComponent<RecipeFood>();
            recipeFood.SetConsumed(false);
            recipeFood.GetImage().sprite = sprite;

            recipeFoods.Add(recipeFood);
        }
    }

    public Food Random()
    {
        return foods[UnityEngine.Random.Range(0, foods.Length)];
    }

    public List<RecipeFood> GetFood()
    {
        return recipeFoods;
    }
}
