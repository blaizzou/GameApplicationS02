using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class ActivateLaser : MonoBehaviour {
    public SteamVR_LaserPointer pointer;
    public GameObject Goal1;
    public GameObject Goal2;
    private Goal g1;
    private Goal g2;
    // Start is called before the first frame update
    void Start () {
        pointer = GetComponent<SteamVR_LaserPointer> ();
        Goal1 = GameObject.Find("/Goal1");
        Goal2 = GameObject.Find("/Goal2");
        g1 = Goal1.GetComponent<Goal> ();
        g2 = Goal2.GetComponent<Goal> ();
    }

    // Update is called once per frame
    void Update () {
        if (g1.score >= 5 || g2.score >= 5) {
            pointer.enabled = true;
        }
    }
}