using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObjectNew : MonoBehaviour
{
    public GameObject circleTarget;

    public Vector3 center;
    public Vector3 size;

    private float time;
    public float destroyDelay;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if(hit.collider != null)
        {
            if (hit.collider.tag == "TargetCircle")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    SpawnNextCircle();
                }
            }
        }
        hideObject(Time.deltaTime);
    }
    public void SpawnNextCircle()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                                           Random.Range(-size.y / 2, size.y / 2), 0);
        Instantiate(circleTarget, pos, Quaternion.identity);

        ScoreScript.scoreValue += 2;
        Destroy(gameObject);
    }
    private void hideObject(float deltaTime)
    {
        if (time < destroyDelay)
        {
            time += deltaTime;
        }
        else
        {
            time = 0;
            SpawnNextCircle();
        }
    }
}
