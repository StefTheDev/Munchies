using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeManager2 : MonoBehaviour
{
    // Singleton
    private static RecipeManager2 instance;
    public static RecipeManager2 Instance { get { return instance; } }

    public GridLayoutGroup grid;
    public Image[] images;

    private LinkedList<Image> imagesList;
    private Food[] foods;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        foods = Resources.LoadAll<Food>("Foods");
        imagesList = new LinkedList<Image>();

        foreach(Image image in imagesList)
        {
            image.sprite = Random().sprite;
        }

        LinkedListNode<Image> imageNode = imagesList.First;
        for (int i = 0; i < images.Length; i++)
        {
            images[i].sprite = imageNode.Value.sprite;
            if (imageNode.Next != null) imageNode = imageNode.Next;
        }
    }

    public void Check(Food food)
    {
        LinkedListNode<Image> image = imagesList.First;
        if (image.Value.sprite = food.sprite) Next(image);

        for(int i = 0; i < images.Length; i++)
        {
            images[i].sprite = image.Value.sprite;
            if(image.Next != null) image = image.Next;
        }
    }

    public void Next(LinkedListNode<Image> image)
    {
        while (image != null)
        {
            image.Value = image.Next.Value;
            image = image.Next;
        }
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
}
