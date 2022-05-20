using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public SpawnerObjectCAM[] circleObject;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        circleObject = FindObjectsOfType<SpawnerObjectCAM>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
