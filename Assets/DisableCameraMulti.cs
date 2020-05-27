using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DisableCameraMulti : MonoBehaviour
{
    private PhotonView PV;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (!PV.IsMine && PhotonNetwork.IsConnected)
            gameObject.SetActive(false);
    }
}
