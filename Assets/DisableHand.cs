using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisableHand : MonoBehaviour
{
    private PhotonView PV;
    [SerializeField]
    private MonoBehaviour hand;
    [SerializeField]
    private MonoBehaviour handPhysics;
    [SerializeField]
    private MonoBehaviour steamBehaviour;
    void Start()
    {
        PV = transform.GetComponent<PhotonView>();
        if (!PV.IsMine && PhotonNetwork.IsConnected)
        {
            hand.enabled = false;
            handPhysics.enabled = false;
            steamBehaviour.enabled = false;
        }
    }

}
