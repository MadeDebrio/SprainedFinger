using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class OnlineGameManager : MonoBehaviour
{
    
    public GameObject Gameover;
    public GameObject myPrefab;    
    public Slider slider;
    

    private void Awake()
    {
        slider.value = 0.5f;
        Time.timeScale = 1;
        ScoreScript.scoreValue = 0;
        myPrefab = FindObjectOfType<MultiplayerSpawn>().gameObject;
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void Update()
    {     
        //Gameover
        if (myPrefab.GetComponent<MultiplayerSpawn>().isLose())
        {
            Time.timeScale = 0;

            //setting screen
            Gameover.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {               
                SceneManager.LoadScene("PlayMode");
            }
        }

    }
    

}
