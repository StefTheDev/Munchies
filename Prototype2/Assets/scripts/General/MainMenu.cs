using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 

    public void OnClickPlay()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
