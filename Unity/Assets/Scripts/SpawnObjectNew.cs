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

    public Slider slider;

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
        else if (missClick())
        {
            slider.value += 0.1f;
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
            decreaseHealthMiss();
        }
    }
    private void decreaseHealthMiss()
    {
        slider.value += 0.1f;
    }
    private bool missClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }
    public bool isLose()
    {
        return slider.value > 0.9f;
    }
}
