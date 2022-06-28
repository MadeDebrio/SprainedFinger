using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HideShowcrc : MonoBehaviour
{
    //public GameOverScreen GameOverScreen;
    public GameObject comsoon;

    public void CSControl()
    {
        comsoon.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            comsoon.SetActive(false);
        }
    }
}
