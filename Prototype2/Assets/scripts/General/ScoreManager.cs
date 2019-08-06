using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    private static ScoreManager instance;

    public static ScoreManager Instance { get { return instance; } }

    public static int finalStars = 0;

    public int fiveStarScore;
    private int playerScore = 0;
    private int scoreMilestone = 0;

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

        finalStars = 0;
    }

    public void AddScore(int score)
    {
        playerScore = Mathf.Clamp(playerScore + score, 0, int.MaxValue);

        if (playerScore >= (fiveStarScore / 5) * (scoreMilestone + 1))
        {
            scoreMilestone++;
            OnGetStar(scoreMilestone);
        }
    }

    public int GetScore()
    {
        return playerScore;
    }

    private void OnGetStar(int starNum)
    {
        finalStars = starNum;

        switch (starNum)
        {
            case 1:
                {

                    Debug.Log("GOT STAR ONE");
                    break;
                }

            case 2:
                {

                    Debug.Log("GOT STAR TWO");
                    break;
                }

            case 3:
                {

                    Debug.Log("GOT STAR THREE");
                    break;
                }

            case 4:
                {

                    Debug.Log("GOT STAR FOUR");
                    break;
                }

            case 5:
                {

                    Debug.Log("GOT STAR FIVE");
                    break;
                }
        }
    }

}
