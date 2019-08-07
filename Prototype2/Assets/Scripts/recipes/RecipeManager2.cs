using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager2 : MonoBehaviour
{
    public GridLayoutGroup grid;
    private Recipe2[] recipes2 = new Recipe2[2];

    public void Create(int index)
    {
        GameObject gameObject = new GameObject("Recipe");
        gameObject.transform.SetParent(transform);

        Recipe2 recipe = gameObject.AddComponent<Recipe2>();
        recipe.Initialise(Random.Range(2, 5));
        recipes2[index] = recipe;
    }

    public void Refresh(Recipe2 recipe)
    {
        List<RecipeFood> recipeFoods = recipe.GetFood();
        for(int i = 0; i < recipeFoods.Count; i++)
        {

        }
    }
}
