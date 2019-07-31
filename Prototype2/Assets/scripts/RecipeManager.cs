using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager : MonoBehaviour
{
    public int size = 0;

    public Recipe recipe;
    public GridLayoutGroup gridLayoutGroup;
    private List<Recipe> recipes;

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
}
