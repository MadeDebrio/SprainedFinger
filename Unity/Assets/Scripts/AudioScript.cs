using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private GameObject[] musicObj;
    
    
    private void Awake()
    {
        musicObj = GameObject.FindGameObjectsWithTag("MUSIK");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
