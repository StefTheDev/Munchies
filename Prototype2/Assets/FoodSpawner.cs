using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Transform conveyorUp;
    public Transform conveyorDown;
    public Transform conveyorLeft;
    public Transform conveyorRight;

    public GameObject[] foodTypes;

    public float beatInterval = 1.0f;
    private float beatTimer = 0.0f;

    private void Awake()
    {
        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    private void Update()
    {
        beatTimer -= Time.deltaTime;

        if (beatTimer <= 0.0f)
        {
            beatTimer = beatInterval;
            SpawnAllConveyors();
        }
    }

    private void SpawnAllConveyors()
    {
        SpawnRandomFood(conveyorUp);
        SpawnRandomFood(conveyorDown);
        SpawnRandomFood(conveyorLeft);
        SpawnRandomFood(conveyorRight);
    }

    private void SpawnRandomFood(Transform foodPosition)
    {
        int foodType = Random.Range(0, foodTypes.Length);

        Instantiate(foodTypes[foodType], foodPosition.position, foodPosition.rotation, null); 
    }
}
