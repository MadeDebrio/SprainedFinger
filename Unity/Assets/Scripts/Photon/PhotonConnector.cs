using UnityEngine;
using System;
using Photon.Pun;
using Photon.Realtime;

namespace SprainedFinger
{
    public class PhotonConnector : MonoBehaviourPunCallbacks
    {
        public static string nickName;
        public static Action GetPhotonFriends = delegate { };
        public static Action OnLobbyJoined = delegate { };

        #region Unity Method
        private void Awake()
        {
            //nickName = PlayerPrefs.GetString("USERNAME");
           
        }

        public void Start()
        {
            if (PhotonNetwork.IsConnectedAndReady || PhotonNetwork.IsConnected) return;

            ConnectToPhoton();
            
        }
        #endregion
        #region Private Methods
        public void ConnectToPhoton()
        {        
            Debug.Log($"Connect to Photon as {nickName}");
            PhotonNetwork.AuthValues = new AuthenticationValues(nickName);
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.NickName = nickName;
            PhotonNetwork.ConnectUsingSettings();
        }
        #endregion
        #region Photon Callbacks
        public override void OnConnectedToMaster()
        {
            Debug.Log("You have connected to the Photon Master Server");
            //if (!PhotonNetwork.InLobby)
            //{
            //    PhotonNetwork.JoinLobby();
            //}
        }
        public override void OnJoinedLobby()
        {
            //Debug.Log("You have connected to a Photon Lobby");
            //Debug.Log("Invoking get Playfab friends");
            //GetPhotonFriends?.Invoke();
            //OnLobbyJoined?.Invoke();
        }
        #endregion


    }
}