using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class OnlineGameManager : MonoBehaviour, IPunObservable
{

      
    
    [SerializeField]PhotonView view;
    private float time;
    [SerializeField]private float playerHealth;

    [Tooltip("The prefab to use for representing the player")]
    public GameObject playerPrefab;
    private GameObject playerPrefabTemp;

    public float destroyDelay;
    public Slider slider;
    public Vector3 center;
    public Vector3 size;
    //public GameObject Gameover;

    private void Awake()
    {
        //view = playerPrefab.GetComponent<PhotonView>();
        view = gameObject.GetComponent<PhotonView>();
        //playerHealth = 0.0f;
        slider.value = 0.5f;
        playerHealth = slider.value;
        Time.timeScale = 1;
        ScoreScript.scoreValue = 0;
        playerPrefabTemp = playerPrefab;
    }
    private void Start()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManager.GetActiveScene()); 
            // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            //PhotonNetwork.Instantiate("CircleHitPoint", new Vector3(0f, 5f, 0f), Quaternion.identity);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Update()
    {
        if (view.IsMine)
        {
            //click
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "TargetCircle")
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        increaseHealthHit();
                        //SFX.playOnSpawn();
                        SpawnNextCircle();
                    }
                }
            }
            else if (missClick())
            {
                time = 0;
                slider.value += 0.03f;
                //SFX.playOnClick();
                SpawnNextCircle();
            }
            hideObject(PhotonNetwork.ServerTimestamp);

            //playerPrefab = FindObjectOfType<MultiplayerSpawn>().gameObject;
            //Gameover
            //if (playerPrefab.GetComponent<MultiplayerSpawn>().isLose())
            //{
            //    Time.timeScale = 0;

            //    //setting screen
            //    Gameover.SetActive(true);
            //    if (Input.GetMouseButtonDown(0))
            //    {               
            //        SceneManager.LoadScene("PlayMode");
            //    }
            //}
        }
    }

    public void SpawnNextCircle()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2),
                                           Random.Range(-size.y / 2, size.y / 2), 0);
        Debug.Log("NewObject");
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);

        PhotonNetwork.Destroy(playerPrefab);
        //DestroyImmediate(playerPrefab, true);
        Debug.Log("ObjectDestroyed");       

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

        if (slider.value > 0.2f)
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
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(slider.value);
            Debug.Log(slider.value);
            //stream.SendNext(ScoreScript.scoreValue);
        }
        else if (stream.IsReading)
        {
            // Network player, receive data
            slider.value = (float)stream.ReceiveNext();
            Debug.Log(slider.value);
            //this. = (bool)stream.ReceiveNext();
        }
    }
    
}
