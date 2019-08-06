using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    private static ScoreManager instance;

    public static ScoreManager Instance { get { return instance; } }

    public int fiveStarScore;
    private int playerScore = 0;

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
    }

    public void AddScore(int score)
    {
        playerScore = Mathf.Clamp(playerScore + score, 0, int.MaxValue);
    }

    public int GetScore()
    {
        return playerScore;
    }


}
