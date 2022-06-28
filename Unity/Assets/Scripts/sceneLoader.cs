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
        SceneManager.LoadScene(3);
    }

    public void Campaign()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayMode()
    {
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    } 

   
}
