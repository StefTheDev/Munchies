using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Singleton
    private static ScoreManager instance;

    public static ScoreManager Instance { get { return instance; } }

    public static int finalStars = 0;

    public int fiveStarScore;
    private int playerScore = 0;
    private int scoreMilestone = 0;

    public Sprite filledStar;

    public Slider scoreBar;

    public Image[] stars;

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

        if (playerScore >= (fiveStarScore / 5) * (scoreMilestone + 1) && scoreMilestone != 5)
        {
            scoreMilestone++;
            OnGetStar(scoreMilestone);
        }

        scoreBar.value = Mathf.Clamp(((float)playerScore / fiveStarScore), 0.0f, 1.0f);
    }

    public int GetScore()
    {
        return playerScore;
    }

    private void OnGetStar(int starNum)
    {
        finalStars = starNum;

        stars[starNum - 1].sprite = filledStar;
        stars[starNum - 1].GetComponent<Animator>().SetTrigger("Get");

        switch (starNum)
        {
            case 1:
                {
                    EnvironmentMaster.Instance.SetStarNumber(1);
                    Debug.Log("GOT STAR ONE");
                    break;
                }

            case 2:
                {
                    EnvironmentMaster.Instance.SetStarNumber(2);
                    Debug.Log("GOT STAR TWO");
                    break;
                }

            case 3:
                {
                    EnvironmentMaster.Instance.SetStarNumber(3);
                    Debug.Log("GOT STAR THREE");
                    break;
                }

            case 4:
                {
                    EnvironmentMaster.Instance.SetStarNumber(4);
                    Debug.Log("GOT STAR FOUR");
                    break;
                }

            case 5:
                {
                    EnvironmentMaster.Instance.SetStarNumber(5);
                    Debug.Log("GOT STAR FIVE");
                    break;
                }
        }
    }

}
