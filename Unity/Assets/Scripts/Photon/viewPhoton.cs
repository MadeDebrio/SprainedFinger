using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
public class viewPhoton : MonoBehaviour
{
    // Start is called before the first frame update
    PhotonView view;
    public TMP_Text username;
    public TMP_Text roomname;
    void Start()
    {
        view = GetComponent<PhotonView>();
        username.text = SprainedFinger.PhotonConnector.nickName;
        roomname.text = PhotonNetwork.CurrentRoom.Name;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

        }
    }
}
