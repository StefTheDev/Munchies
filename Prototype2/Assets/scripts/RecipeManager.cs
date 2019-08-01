using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    // Singleton
    private static RecipeManager instance;

    public static RecipeManager Instance { get { return instance; } }

    public int size = 0;
    public static int foodScore = 10;

    public Recipe recipe;
    public GridLayoutGroup gridLayoutGroup;
    public List<Recipe> recipes;

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
    }

    private void Start()
    {
        this.recipes = new List<Recipe>();

        for (int i = 0; i < size; i++)
        {
            if(i != 0)
            this.recipes.Add(Instantiate(
                this.recipe, 
                Vector3.zero,
                Quaternion.identity,
                gridLayoutGroup.transform).Initialise(Random.Range(4, 8))
            );
        }
    }

    public bool CheckFood(HealthyFoodType foodType)
    {
        if (recipes[0].GetSize() == 0)
        {
            recipes.RemoveAt(0);
        }

        if (recipes[0].GetNextFood() == foodType)
        {
            recipes[0].AdvanceRecipe();
            return true;
        }

        return false;
        
    }
}
