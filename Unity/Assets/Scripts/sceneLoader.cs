using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CrazzyMode()
    {
        SceneManager.LoadScene("CrazzyMode");
    }

    public void Campaign()
    {
        SceneManager.LoadScene("Campaign");
    }

    public void Multiplayer()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void LoadingScene()
    {
        SceneManager.LoadScene("LOADING");
    }

    public void PlayMode()
    {
        SceneManager.LoadScene("PlayMode");
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    } 

   
}
