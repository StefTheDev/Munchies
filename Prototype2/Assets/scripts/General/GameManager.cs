using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public int score = 0;

    public Slider healthSlider;
    public Slider hungerSlider;

    private Player player;
    private Conveyor[] conveyors;

    public float beatInterval = 1.0f;
    private float beatTimer = 0.0f;

    private void Awake()
    {
        // Singleton
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        Random.InitState((int)System.DateTime.Now.Ticks);
        player = GameObject.FindObjectOfType<Player>();
        conveyors = GameObject.FindObjectsOfType<Conveyor>();

        healthSlider.maxValue = player.maxHealth;
        hungerSlider.maxValue = player.maxFullness;
    }

    private void Update()
    {
        beatTimer -= Time.deltaTime;

        if (beatTimer <= 0.0f)
        {
            beatTimer = beatInterval;
            GameBeat();
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    private void FixedUpdate()
    {

        healthSlider.value = player.currentHealth;
        hungerSlider.value = player.currentFullness;
    }

    private void GameBeat()
    {
        player.eatenThisBeat = false;
        player.Beat();

        foreach (Conveyor conveyor in conveyors)
        {
            conveyor.Beat();
        }
    }
}
