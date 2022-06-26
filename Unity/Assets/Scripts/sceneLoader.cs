using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CrazzyMode()
    {
        SceneManager.LoadScene(3);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
