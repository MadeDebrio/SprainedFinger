using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    public GameObject circleObject;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject",2,1);
    }
    Vector2 GetSpawnPoint()
    {
        float x = Random.Range(-6f, 6f);
        float y = Random.Range(-4f, 4f);
        return new Vector2(x, y);
    }
    void SpawnObject()
    {
        Instantiate(circleObject, GetSpawnPoint(), Quaternion.identity);
    }
}
