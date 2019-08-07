using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeFood : MonoBehaviour
{
    private bool consumed;
    private Image image;

    private void Start()
    {
        image = gameObject.AddComponent<Image>();
    }

    public void SetConsumed(bool consumed)
    {
        this.consumed = consumed;
    }

    public bool IsConsumed()
    {
        return consumed;
    }

    public Image GetImage()
    {
        return image;
    }
}
