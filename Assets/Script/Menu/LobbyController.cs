using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.UI;

public class LobbyController : MonoBehaviourPunCallbacks {
    [SerializeField]
    private GameObject lobbyConnectButton;
    [SerializeField]
    private GameObject lobbyPanel;
    [SerializeField]
    private GameObject mainPanel;
    [SerializeField]
    private InputField playerNameInput;

    private string roomName;
    private int roomSize;

    private List<RoomInfo> roomListings;
    [SerializeField]
    private Transform roomsContainer;
    [SerializeField]
    private GameObject roomListingPrefab;

    public override void OnConnectedToMaster () {
        PhotonNetwork.AutomaticallySyncScene = true;
        lobbyConnectButton.SetActive (true);
        roomListings = new List<RoomInfo> ();
        if (PlayerPrefs.HasKey ("NickName")) {
            if (PlayerPrefs.GetString ("NickName") == "") {
                PhotonNetwork.NickName = "Player" + Random.Range (0, 10000);
            } else {
                PhotonNetwork.NickName = PlayerPrefs.GetString ("NickName");
            }
        } else {
            PhotonNetwork.NickName = "Player" + Random.Range (0, 10000);
        }
        playerNameInput.text = PhotonNetwork.NickName;
    }

    public void playerNameUpdate (string nameInput) {
        PhotonNetwork.NickName = nameInput;
        PlayerPrefs.SetString ("NickName", nameInput);
    }

    public void JoinLobbyOnClick () {
        mainPanel.SetActive (false);
        lobbyPanel.SetActive (true);
        PhotonNetwork.JoinLobby ();
    }

    public override void OnRoomListUpdate (List<RoomInfo> roomlist) {
        int tempIndex;

        foreach (RoomInfo room in roomlist) {
            if (roomListings != null) {
                tempIndex = roomListings.FindIndex(ByName(room.Name));
            } else {
                tempIndex = -1;
            }
            if (tempIndex != -1) {
                roomListings.RemoveAt(tempIndex);
                Destroy (roomsContainer.GetChild(tempIndex).gameObject);
            }
            if (room.PlayerCount > 0) {
                roomListings.Add(room);
                ListRoom(room);
            }
        }
    }

    static System.Predicate<RoomInfo> ByName (string name) {
        return delegate (RoomInfo room) {
            return room.Name == name;
        };
    }

    void ListRoom (RoomInfo room) {
        if (room.IsOpen && room.IsVisible) {
            GameObject tempListing = Instantiate (roomListingPrefab, roomsContainer);
            RoomButton tempButton = tempListing.GetComponent<RoomButton> ();
            tempButton.SetRoom (room.Name, room.MaxPlayers, room.PlayerCount);
        }
    }

    public void OnRoomNameChanged (string nameIn) {
        roomName = nameIn;
    }

    public void OnRoomSizeChanged (string sizeIn) {
        roomSize = int.Parse (sizeIn);
    }

    public void CreateRoom () {
        Debug.Log ("creating Room");
        RoomOptions option = new RoomOptions () { IsVisible = true, IsOpen = true, MaxPlayers = (byte) roomSize };
        option.CustomRoomProperties = new Hashtable() {{"ready", 1}};
        PhotonNetwork.CreateRoom (roomName, option);
    }

    public void MatchMakingCancel () {
        mainPanel.SetActive (true);
        lobbyPanel.SetActive (false);
        PhotonNetwork.LeaveLobby ();
    }

}