using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomController : MonoBehaviourPunCallbacks {

    public Text selectedText;
    [SerializeField]
    private int multiplayerSceneIndex;
    // private RoomInfos RI;
    [SerializeField]
    private GameObject lobbyPanel;
    [SerializeField]
    private GameObject roomPanel;

    [SerializeField]
    private GameObject startButton;

    [SerializeField]
    private GameObject readyButton;

    [SerializeField]
    private Transform playerContainer;

    [SerializeField]
    private GameObject playerListingPrefab;
    [SerializeField]
    private Text roomNameDisplay;

    private int ready;
    private bool playerReady = false;

    void clearPlayerListing () {
        for (int i = playerContainer.childCount - 1; i >= 0; i--) {
            Destroy (playerContainer.GetChild (i).gameObject);
        }
    }

    void ListPlayers () {
        foreach (Player player in PhotonNetwork.PlayerList) {
            GameObject tempListing = Instantiate (playerListingPrefab, playerContainer);
            Text tempText = tempListing.transform.GetChild (0).GetComponent<Text> ();
            tempText.text = player.NickName;
        }
    }

    public override void OnJoinedRoom () {
        Debug.Log ("Joined Room");
        roomPanel.SetActive (true);
        lobbyPanel.SetActive (false);
        roomNameDisplay.text = PhotonNetwork.CurrentRoom.Name;
        if (PhotonNetwork.IsMasterClient) {
            Debug.Log ("tt");
        } else {
            readyButton.SetActive (true);
        }
        clearPlayerListing ();
        ListPlayers ();

    }

    public override void OnPlayerEnteredRoom (Player newPlayer) {
        clearPlayerListing ();
        ListPlayers ();
        if (PhotonNetwork.IsMasterClient) {
            ready = (int) PhotonNetwork.CurrentRoom.CustomProperties["ready"];
            Hashtable hash = new Hashtable ();
            hash.Add ("ready", ready);
            PhotonNetwork.CurrentRoom.SetCustomProperties (hash);
        }
    }

    public override void OnPlayerLeftRoom (Player otherPlayer) {
        clearPlayerListing ();
        ListPlayers ();
        if (PhotonNetwork.IsMasterClient) {
            startButton.SetActive (true);
        }
    }

    public void startGame () {
        if (PhotonNetwork.IsMasterClient) {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.LoadLevel (multiplayerSceneIndex);
        }
    }

    IEnumerator rejoinLobby () {
        yield return new WaitForSeconds (2);
        PhotonNetwork.JoinLobby ();
    }

    public void BackOnClick () {
        lobbyPanel.SetActive (true);
        roomPanel.SetActive (false);
        PhotonNetwork.LeaveRoom ();
        PhotonNetwork.LeaveLobby ();
        StartCoroutine (rejoinLobby ());
    }

    public override void OnEnable () {
        PhotonNetwork.AddCallbackTarget (this);

    }

    public override void OnDisable () {
        PhotonNetwork.RemoveCallbackTarget (this);
    }

    private void StartGame () {
        if (PhotonNetwork.IsMasterClient) {
            Debug.Log ("starting game");
            PhotonNetwork.LoadLevel (multiplayerSceneIndex);
        }
    }

    // Start is called before the first frame update
    void Start () {
        selectedText.text = "You have selected : char 1"; 
        if (PhotonNetwork.IsMasterClient) {
            Hashtable hash = new Hashtable ();
            hash.Add ("ready", 1);
            PhotonNetwork.CurrentRoom.SetCustomProperties (hash);
        }
    }

    // Update is called once per frame
    void Update () {
        ready = (int) PhotonNetwork.CurrentRoom.CustomProperties["ready"];
        Debug.Log (ready);
        if (ready >= PhotonNetwork.PlayerList.Length && !playerReady && PhotonNetwork.IsMasterClient) {
            startButton.SetActive (true);
        } else if (!(ready == PhotonNetwork.PlayerList.Length) && !playerReady && PhotonNetwork.IsMasterClient) {
            startButton.SetActive (false);
        }
    }
}