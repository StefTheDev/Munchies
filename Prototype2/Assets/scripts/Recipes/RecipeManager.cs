using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    // Singleton
    private static RecipeManager instance;

    public static RecipeManager Instance { get { return instance; } }

    public static int foodScore = 10;

    public Recipe recipePrefab;
    public GridLayoutGroup gridLayoutGroup;
     
    private Recipe currentRecipe, nextRecipe;
    private Image image;

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

        nextRecipe = Instantiate(recipePrefab, transform, false);
        nextRecipe.Initialise(Random.Range(4, 8));
        CreateRecipe();
    }

    private void CreateRecipe()
    {
        currentRecipe = nextRecipe;
        nextRecipe = Instantiate(recipePrefab, transform, false);
        nextRecipe.Initialise(Random.Range(4, 8));
    }

    public void CheckFood(HealthyFoodType foodType)
    {
        if (foodType == currentRecipe.GetNextFood())
        {
            currentRecipe.AdvanceRecipe();

            Debug.Log("Correct food item eaten!");

            if (currentRecipe.GetSize() == 0)
            {
                PassRecipe();
            }
        }
        else
        {
            FailRecipe();
        }
    }

    private void PassRecipe()
    {
        currentRecipe.Completed();

        Destroy(currentRecipe);
        CreateRecipe();

        Debug.Log("Recipe completed!");
    }

    private void FailRecipe()
    {
        Destroy(currentRecipe);
        CreateRecipe();

        Debug.Log("Recipe failed!");
    }
}
