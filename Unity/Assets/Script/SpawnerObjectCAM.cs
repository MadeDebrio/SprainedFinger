using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObjectCAM : MonoBehaviour
{
    public SpriteRenderer theSR;
    public GameObject circleTarget;
    public Vector3 pos;

    private void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        pos = gameObject.transform.position;
        Debug.Log(pos);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        // If it hits something...
        if (hit.collider != null)
        {
            Debug.Log("asddfa");
            if (hit.collider.tag == "TargetCircle")
            {
                Debug.Log("fgdg");
                theSR.color = Color.black;
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("asda");
                    SpawnNextCircle();
                }
            }
            else
            {
                theSR.color = Color.white;
            }
        }
    }
    public void SpawnNextCircle()
    {
        
        //Instantiate(gameObject, pos, Quaternion.identity);//Quaternion.identity : No rotation
        Destroy(gameObject);
    }
}
