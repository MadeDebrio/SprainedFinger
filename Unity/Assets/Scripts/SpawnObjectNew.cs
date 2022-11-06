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
    private SpriteRenderer visible;

    public MusicManager SFX;
    

    private void Start()
    {
        visible = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //click
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if(hit.collider != null)
        {
            if (hit.collider.tag == "TargetCircle")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    increaseHealthHit();
                    SFX.playOnSpawn();
                    SpawnNextCircle();
                }
            }
        }
        else if (missClick())
        {
            time = 0;
            slider.value += 0.03f;
            SFX.playOnClick();
            SpawnNextCircle();
        }
        hideObject(Time.deltaTime);

        //ObjVisibility
        if (Time.timeScale == 1)
        {
            visible.enabled = true;
        }
        else if(Time.timeScale == 0)
        {
            visible.enabled = false;
        }

    }
    public void SpawnNextCircle()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                                           Random.Range(-size.y / 2, size.y / 2), 0);
        Instantiate(circleTarget, pos, Quaternion.identity);        
        
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
            slider.value += 0.06f;
 
    }
    
    private void increaseHealthHit()
    {
        ScoreScript.scoreValue += 2;

        if (slider.value>0.2f)
        {
            slider.value -= 0.03f;
        }
        
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
