using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Photon.Pun;

public class ValveInput : MonoBehaviour
{
    private GameObject ball;
    private GameObject Lefthand;

    private int maxCounter = 50;
    private int counter;
    private bool hold = false;
    private PhotonView PV;

    private void Start()
    {
        if (!PV.IsMine && PhotonNetwork.IsConnected)
            this.enabled = false;
        ball = GameObject.FindGameObjectWithTag("projectile");
        Lefthand = GameObject.FindGameObjectWithTag("LeftHand");
    }
    void Update()
    {

        if (SteamVR_Actions.default_DropBall.changed && hold)
            hold = false;
        else if (SteamVR_Actions.default_DropBall.changed)
            hold = true;
        if ((SteamVR_Actions.default_DropBall.changed || hold))
            AppearBall();

        counter++;
        
    }

    void AppearBall()
    {
        ball.transform.position = Lefthand.transform.position;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        counter = 0;
    }
}
