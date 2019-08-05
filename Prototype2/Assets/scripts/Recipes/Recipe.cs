using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Recipe : MonoBehaviour
{
    public List<Image> images;
    public Sprite check;

    private int completionScore;
    private Food[] foods;

    private int currentIndex;

    public void Initialise(List<Image> images)
    {
        foods = Resources.LoadAll<Food>("Foods");
        currentIndex = 0;

        if (images == null)
        {

            for (int i = 0; i < this.images.Count; i++)
            {
                Image image = this.images[i];
                image.sprite = Random().sprite;
                currentIndex++;
            }
        }
        else
        {
            Debug.Log("Swapping...");
            for (int i = 0; i < this.images.Count; i++)
            {
                Image image = this.images[i];
                image.sprite = images[i].sprite;
                currentIndex++;
            }
        }

        completionScore = RecipeManager.foodScore * currentIndex;
    }

    public bool Check(Food food)
    {
        Image image = images[currentIndex - 1];
        if (food.sprite.name.Equals(image.sprite.name))
        {
            images[currentIndex- 1].sprite = check;
            currentIndex -= 1;
            return true;
        }
        return false;
    }

    private Food Random()
    {
        System.Random random = new System.Random();
        Food food = foods[UnityEngine.Random.Range(0, foods.Length)];
        if (food.isHealthy)
        {
            return food;
        }
        else
        {
            return Random();
        }
    }

    public int GetIndex()
    {
        return currentIndex;
    }

    public void Complete()
    {
        GameManager.Instance.AddScore(completionScore);
    }

    public List<Image> GetImages()
    {
        return images;
    }
}
