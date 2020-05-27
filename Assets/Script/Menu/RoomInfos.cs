using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
public class RoomInfos : MonoBehaviour
{

    
    [SerializeField]
    private GameObject cancelButton;
    
    [SerializeField]
    private GameObject readyButton;

    // Start is called before the first frame update
    public void readyOnClick () {
        int ready = (int) PhotonNetwork.CurrentRoom.CustomProperties["ready"];
        ready++;
        Hashtable hash = new Hashtable ();
        hash.Add ("ready", ready);
        PhotonNetwork.CurrentRoom.SetCustomProperties (hash);
        readyButton.SetActive(false);
        cancelButton.SetActive(true);
    }

    public void cancelOnClick() {
        int ready = (int) PhotonNetwork.CurrentRoom.CustomProperties["ready"];
        ready--;
        Hashtable hash = new Hashtable ();
        hash.Add ("ready", ready);
        PhotonNetwork.CurrentRoom.SetCustomProperties (hash);
        readyButton.SetActive(true);
        cancelButton.SetActive(false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
