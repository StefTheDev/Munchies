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

    public float beatInterval = 1.0f;
    private float beatTimer = 0.0f;

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

        Random.InitState((int)System.DateTime.Now.Ticks);
    }

    private void Update()
    {
        beatTimer -= Time.deltaTime;

        if (beatTimer <= 0.0f)
        {
            beatTimer = beatInterval;
            OnBeat();
        }
    }

    public void OnBeat()
    {
        var player = GameObject.FindObjectOfType<Player>();
        player.eatenThisBeat = false;

        var conveyors = FindObjectsOfType<Conveyor>();

        foreach(Conveyor conveyor in conveyors)
        {
            conveyor.Beat();
        }
    }
}
