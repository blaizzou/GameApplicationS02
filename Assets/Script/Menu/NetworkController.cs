using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public  override void OnConnectedToMaster() {
        Debug.Log("Successfully connected to " + PhotonNetwork.CloudRegion );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
