using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager2 : MonoBehaviour
{
    public GridLayoutGroup grid;
    public Image[] images;

    private Food[] foods;

    private void Start()
    {
        foods = Resources.LoadAll<Food>("Foods");
    }

    public void Refresh()
    {
        
    }

    public void Check(Food food)
    {
        Image image = images[0];
        if (image.sprite = food.sprite) Next();
    }

    public void Next()
    {
        for(int i = 0; i < images.Length; i++)
        {
            if(i != (images.Length - 1)) {
                images[i].sprite = images[i - 1].sprite;
            }
            else
            {
                images[images.Length - 1].sprite = this.Random();
            }
        }
    }

    private Sprite Random()
    {
        return foods[UnityEngine.Random.Range(0, foods.Length)].sprite;
    }
}
