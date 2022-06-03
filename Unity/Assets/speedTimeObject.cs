using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedTimeObject : MonoBehaviour
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
        float delay = GetComponent<SpawnObjectNew>().destroyDelay - 1;
        if (delay <= 1)
        {
            enabled = false;
            yield return null;
        }
        GetComponent<SpawnObjectNew>().destroyDelay = delay;
        yield return new WaitForSeconds(5);
    }
}