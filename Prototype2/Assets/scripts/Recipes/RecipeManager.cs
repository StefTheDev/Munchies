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

    public Recipe currentRecipe, nextRecipe;

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

        currentRecipe.Initialise(null);
        nextRecipe.Initialise(null);
    }

    public void Check(Food food)
    {
        if(currentRecipe.Check(food))
        {
            if (currentRecipe.GetIndex() == 0)
            {
                Debug.Log("Time for next recipe.");
                Next(true);
            }
        }
        else
        {
            Next(false);
        }
    }

    public void Next(bool completed)
    {
        if (completed) currentRecipe.Complete();

        currentRecipe.Initialise(nextRecipe.GetImages());
        nextRecipe.Initialise(null);
    }
}
