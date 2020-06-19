using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerOnline : MonoBehaviour
{

    [SerializeField]
    private GameObject playerVR;
    private Transform ball;
    private PhotonView PV;
    private bool mine = false;
    void Start()
    {
        playerVR.SetActive(true);
        PV = transform.GetComponent<PhotonView>();
        ball = GameObject.FindGameObjectWithTag("projectile").transform;
    }

    void Update()
    {
        if (PV.IsMine)
        {
            float dist = Vector3.Distance(ball.position, transform.position);
            if (dist < 3 && !mine)
            {
                ball.GetComponent<PhotonView>().RequestOwnership();
                mine = true;
            }
            else
                mine = false;
        }
    }
}
