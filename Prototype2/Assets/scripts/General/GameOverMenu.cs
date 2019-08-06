using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI title;
    public GameObject[] stars;


    private void Start()
    {
        for (int i = 0; i < ScoreManager.finalStars; i++)
        {
            if (!stars[i]) { break; }
            stars[i].SetActive(true);
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
