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
    //public GameObject cirle;
    public  GameObject myPrefab;
    //public SpawnObjectNew spawnScript;
    public Slider slider;
    //public PlayfabManager playfabManager;
    public Leaderboard playfabLeaderboard;

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
        myPrefab = FindObjectOfType<SpawnObjectNew>().gameObject;
        
        //Gameover
        if (myPrefab.GetComponent<SpawnObjectNew>().isLose())
        {
            Time.timeScale = 0;
            
            //setting screen
            Gameover.SetActive(true);           
            if (Input.GetMouseButtonDown(0))
            {
                playfabLeaderboard.SendLeaderboard(ScoreScript.scoreValue);                
                SceneManager.LoadScene("PlayMode");
            }
        }     

    }
}
