using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class JoinLobby : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private byte maxPlayers = 2;

    public void Start()
    {
        StartCoroutine(FoundMatch());
    }

    private void CreateRoom()
    {
        //RoomOptions roomOptions = new RoomOptions();
        //roomOptions.MaxPlayers = maxPlayers;
        //PhotonNetwork.CreateRoom(null, roomOptions, null);
        int randomRoomName = Random.Range(0, 5000);
        RoomOptions roomOptions = new RoomOptions() {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 2          
        };
        PhotonNetwork.CreateRoom("RoomName_"+ randomRoomName, roomOptions);
        Debug.Log("Room Created , Waiting For Another Player");
    }

    private void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Searching for a Game");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Couldnt Find a Room -- Creating Room");
        CreateRoom();
    }

    public override void OnJoinedRoom()
    {
        // joined a room successfully
        Debug.Log("You have connected to a Photon Lobby");
        Debug.Log("Invoking get Playfab friends");
        Debug.Log("Room Name : "+ PhotonNetwork.CurrentRoom.Name);
        //PhotonConnector.GetPhotonFriends?.Invoke();
        //OnLobbyJoined?.Invoke();
        //SceneManager.LoadScene("Multiplayer");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount==2&&PhotonNetwork.IsMasterClient)
        {
            Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount+"/2 Starting Game");
            SceneManager.LoadScene("Multiplayer");
        }
        base.OnPlayerEnteredRoom(newPlayer);
    }

    public void stopSearch()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Stopped, back to menu");
        SceneManager.LoadScene("PlayMode");        
    }
    IEnumerator FoundMatch()
    {
        yield return new WaitForSeconds(5.0f);
        QuickMatch();
    }

}