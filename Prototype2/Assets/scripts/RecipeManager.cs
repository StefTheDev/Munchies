using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    public int size = 0;

    public Recipe recipePrefab;
    public GridLayoutGroup gridLayoutGroup;

    private Recipe recipe;
    private Image image;

    private void FixedUpdate()
    {
        if(recipe == null)
        {
            CreateRecipe();
        }
        else if (recipe.IsFinished())
        {
            // We can give a special indication that the recipe is finished.
            Destroy(recipe);
            CreateRecipe();

        }
        else if (recipe.IsNotMatching(image))
        {
            //We give an indication that the next item was wron and it needs a new recipe.
            Destroy(recipe);
            CreateRecipe();
        }
    }

    private void CreateRecipe()
    {
        recipe = Instantiate(recipePrefab, transform, false);
        recipe.Initialise(Random.Range(4, 8));
    }
}
