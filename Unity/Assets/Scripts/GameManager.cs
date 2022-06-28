using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    //public GameOverScreen GameOverScreen;
    public GameObject panelPause;
    public GameObject Gameover;
    //public GameObject cirkel;   
    public SpawnObjectNew spawnScript;
    public Slider slider;

    private void Awake()
    {
        slider.value = 0.5f;
        Time.timeScale = 1;
        ScoreScript.scoreValue = 0;

    }

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
        //Gameover
        if (spawnScript.isLose())
        {            
            Time.timeScale = 0;
            Gameover.SetActive(true);           
            if (Input.GetMouseButtonDown(0))
            {               
                SceneManager.LoadScene(0);
            }
        }     

    }
}
