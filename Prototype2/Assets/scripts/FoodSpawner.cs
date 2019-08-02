using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // Singleton
    private static FoodSpawner instance;

    public static FoodSpawner Instance { get { return instance; } }

    public Transform conveyorUp;
    public Transform conveyorDown;
    public Transform conveyorLeft;
    public Transform conveyorRight;

    public GameObject[] foodTypes;

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

}
