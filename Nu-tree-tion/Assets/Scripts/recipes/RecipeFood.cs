using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum FoodState
{
    ACTIVE,
    INACTIVE,
    COMPLETE
}

public class RecipeFood : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;
    public FoodState foodState;

    public void Refresh()
    {
        switch(foodState)
        {
            case FoodState.ACTIVE:
                image.sprite = sprites[0];
                break;
            case FoodState.INACTIVE:
                image.sprite = sprites[1];
                break;
            case FoodState.COMPLETE:
                image.sprite = sprites[2];
                break;
        }
    }
}
