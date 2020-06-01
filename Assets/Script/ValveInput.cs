using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ValveInput : MonoBehaviour
{
    public GameObject ball;
    public Transform Lefthand;

    private int maxCounter = 50;
    private int counter;
    private bool hold = false;
    void Update()
    {

        if (SteamVR_Actions.default_DropBall.changed && hold)
        {
            hold = false;
            print("drop");
        }
        else if (SteamVR_Actions.default_DropBall.changed)
        {
            hold = true;

        }
        if ((SteamVR_Actions.default_DropBall.changed || hold))
            AppearBall();

        counter++;
        
    }

    void AppearBall()
    {
        print("oui");
        ball.transform.position = Lefthand.position;
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        counter = 0;
    }
}
