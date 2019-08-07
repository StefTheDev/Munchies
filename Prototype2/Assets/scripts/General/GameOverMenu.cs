using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI title;
    public Image[] stars;
    public Sprite filledStar;

    private void Start()
    {
        for (int i = 0; i < ScoreManager.finalStars; i++)
        {
            if (!stars[i]) { break; }
            stars[i].sprite = filledStar;
        } 

        if (GameManager.playerWon)
        {
            title.text = "You Win!";
        }
        else
        {
            title.text = "Game Over";
        }
    }

    public void OnClickBack()
    {
        SceneManager.LoadSceneAsync("MenuScene");
    }
}
