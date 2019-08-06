using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public int score = 0;

    public TextMeshPro tempScoreText;
    public TextMeshPro tempHealthText;
    public TextMeshPro tempFullnessText;

    public AudioSource levelMusic;

    private Player player;
    private Conveyor[] conveyors;

    public float beatInterval = 1.0f;
    private float beatTimer = 0.0f;

    private bool levelComplete = false;
    private bool paused = false;

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
    }

    private void Update()
    {
        beatTimer -= Time.deltaTime;

        if (beatTimer <= 0.0f)
        {
            beatTimer = beatInterval;
            GameBeat();
        }

        if (Input.GetKeyDown(KeyCode.P)) { TogglePause(); }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        tempScoreText.text = "Score: " + score;
    }

    private void FixedUpdate()
    {
        tempHealthText.text = "Health: " + player.currentHealth;
        tempFullnessText.text = "Fullness: " + player.currentFullness;

        
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

    public void TogglePause()
    {
        if (paused)
        {
            Time.timeScale = 0.0f;
            levelMusic.Pause();
        }
        else
        {
            Time.timeScale = 1.0f;
            levelMusic.UnPause();
        }

        paused = !paused;
    }
}
