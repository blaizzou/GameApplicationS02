using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using System.Collections.ObjectModel;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    public float spawnTime;
    private float timer;
    private Hand hand;

    void Start() {
        // Instantiate(ball, transform.position, transform.rotation);
        hand = GetComponent<Hand>();
/*        Controller = GetComponent<SteamVR_TrackedController>();
        Controller.PadClicked += onPadClicked;
        Controller.PadUnclicked += onPadUnclicked;*/
    }

/*    public void onPadClicked(object sender, ClickedEventArgs e)
    {
        Debug.Log(“Pad is clicked”);
    }
*/
    void Update()
    {
/*        if (hand.controller.GetHairTriggerDown())
        {
            Debug.Log("Trigger");
        }*/

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Instantiate(ball, transform.position, transform.rotation);
            timer = 2f;
        }
    }
}
