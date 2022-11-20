using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineSpeedObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(functionCall());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator functionCall()
    {
        float delay = (float)((float)GetComponent<MultiplayerSpawn>().destroyDelay - 0.2);
        if (delay <= 0.7)
        {
            enabled = false;
            yield return null;
        }
        GetComponent<MultiplayerSpawn>().destroyDelay = delay;
        yield return new WaitForSeconds(15);
    }
}