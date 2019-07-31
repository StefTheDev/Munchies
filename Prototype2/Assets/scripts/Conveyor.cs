using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PushDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class Conveyor : MonoBehaviour
{
    public Transform[] movePositions;
    private List<GameObject> foodObjects;

    private void Awake()
    {
        foodObjects = new List<GameObject>();
    }


    public void Beat()
    {
        

        // For all live food objects spawned by this conveyor

        // Increment their move positions

        // If they're not at the end of the belt, move them to the next position

        // Otherwise, push them off the belt

        // Turn on gravity


        for (int i = 0; i < foodObjects.Count; i++)
        {
            var food = foodObjects[i].GetComponent<Food>();
            food.movePosition++;

            food.gameObject.transform.position = movePositions[food.movePosition].position;

            if (food.movePosition >= (movePositions.Length - 1))
            {
                food.gameObject.GetComponent<Rigidbody>().useGravity = true;
                // food.gameObject.GetComponent<Rigidbody>().AddForce()
                foodObjects.RemoveAt(i);
                i--;
            }
                       
        }

        // Spawn new food objects
        SpawnRandomFood();
    }

    public void SpawnRandomFood()
    {
        int foodType = Random.Range(0, FoodSpawner.Instance.foodTypes.Length);

        foodObjects.Add(Instantiate(FoodSpawner.Instance.foodTypes[foodType], movePositions[0].position, movePositions[0].rotation, null));
    }
}
