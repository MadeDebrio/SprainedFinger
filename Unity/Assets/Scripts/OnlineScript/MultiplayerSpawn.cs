using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class MultiplayerSpawn : MonoBehaviour
{

    public GameObject circleTarget;

    PhotonView view;

    public Vector3 center;
    public Vector3 size;

    //private float time;
    public float destroyDelay;

    //public Slider slider;
    private SpriteRenderer visible;

    public MusicManager SFX;
   

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        
    }

    private void Start()
    {
        
        visible = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        //if (view.IsMine) {
        //    //click
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        //    RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        //    if (hit.collider != null)
        //    {
        //        if (hit.collider.tag == "TargetCircle")
        //        {
        //            if (Input.GetMouseButtonDown(0))
        //            {
        //                increaseHealthHit();
        //                SFX.playOnSpawn();
        //                SpawnNextCircle();
        //            }
        //        }
        //    }
        //    else if (missClick())
        //    {
        //        time = 0;
        //        slider.value += 0.03f;
        //        SFX.playOnClick();
        //        SpawnNextCircle();
        //    }
        //    hideObject(Time.deltaTime);            
        //}       

    }
    public void SpawnNextCircle()
    {
        //Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
        //                                   Random.Range(-size.y / 2, size.y / 2), 0);
        //Debug.Log("NewObject");
        //PhotonNetwork.Instantiate("CircleHitPoint", pos, Quaternion.identity);

        //PhotonNetwork.Destroy(gameObject);
        //Debug.Log("ObjectDestroyed");

    }
    private void hideObject(float deltaTime)
    {
        //if (time < destroyDelay)
        //{
        //    time += deltaTime;
        //}
        //else
        //{
        //    time = 0;
        //    SpawnNextCircle();
        //    decreaseHealthMiss();
        //}
    }
    private void decreaseHealthMiss()
    {
        //slider.value += 0.06f;

    }

    private void increaseHealthHit()
    {
        //ScoreScript.scoreValue += 2;

        //if (slider.value > 0.2f)
        //{
        //    slider.value -= 0.03f;
        //}

    }

    //private bool missClick()
    //{
    //    //if (Input.GetMouseButtonDown(0))
    //    //{
    //    //    return true;
    //    //}
    //    //return false;
    //}
    //public bool isLose()
    //{
    //    //return slider.value > 0.9f;
    //}
}
