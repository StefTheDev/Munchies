using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    public int score = 0;

    public Slider hungerSlider;

    public AudioSource levelMusic;

    private Player player;
    private Conveyor[] conveyors;

    public float beatInterval = 1.0f;
    private float beatTimer = 0.0f;

    public float songDuration;
    private float songTimer = 0.0f;

    public int freeBeats = 4;

    private bool levelComplete = false;
    private bool paused = false;

    static public bool playerWon = false;

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

        hungerSlider.maxValue = player.maxFullness;
    }

    private void Update()
    {
        beatTimer -= Time.deltaTime;
        songTimer += Time.deltaTime;

        if (beatTimer <= 0.0f)
        {
            beatTimer = beatInterval;
            GameBeat();
        }

        if (songTimer >= songDuration)
        {
            LevelComplete();
        }

        if (Input.GetKeyDown(KeyCode.P)) { TogglePause(); }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        ScoreManager.Instance.AddScore(newScore);
    }

    private void FixedUpdate()
    {
        hungerSlider.value = player.currentFullness;
    }

    private void GameBeat()
    {
        player.eatenThisBeat = false;
        player.Beat();
        if (freeBeats > 0) { freeBeats--; }

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

    private void LevelComplete()
    {
        playerWon = true;
        SceneManager.LoadSceneAsync("GameOverScene");
    }

    public void GameOver()
    {
        playerWon = false;
        SceneManager.LoadSceneAsync("GameOverScene");
    }
}
