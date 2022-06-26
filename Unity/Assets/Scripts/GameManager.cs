using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameOverScreen GameOverScreen;
    public GameObject panelPause;
    public SpawnObjectNew spawnobject;

    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
                panelPause.SetActive(false);
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Update()
    {
        if (spawnobject.isLose())
        {
            Debug.Log("kalah");
        }
    }
}
