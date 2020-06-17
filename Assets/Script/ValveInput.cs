using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ValveInput : MonoBehaviour {
    public CanvasGroup uiElement;
    private bool UI = false;
    private int tmp = 0;
    private GameObject ball;
    private GameObject Lefthand;

    private int maxCounter = 50;
    private int counter;
    private bool hold = false;
    private PhotonView PV;

    void Start () {
        PV = transform.GetComponent<PhotonView> ();
        /* if (!PV.IsMine && PhotonNetwork.IsConnected)
             this.enabled = false;*/
        ball = GameObject.FindGameObjectWithTag ("projectile");
        Lefthand = GameObject.FindGameObjectWithTag ("LeftHand");
    }
    void Update () {
        tmp++;
        Debug.Log (tmp);
        if (tmp >= 500) {
            tmp = 0;
            if (UI)
                FadeIn ();
            else
                FadeOut ();
            UI = !UI;
        }
        if (SteamVR_Actions.default_DropBall.changed && hold)
            hold = false;
        else if (SteamVR_Actions.default_DropBall.changed)
            hold = true;
        if ((SteamVR_Actions.default_DropBall.changed || hold))
            AppearBall ();
        if (SteamVR_Actions.default_fade_UI.changed)

            counter++;

    }

    void AppearBall () {
        ball.transform.position = Lefthand.transform.position;
        ball.GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
        counter = 0;
    }

    public void FadeIn () {
        StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 1, .5f));
    }

    public void FadeOut () {
        StartCoroutine (FadeCanvasGroup (uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup (CanvasGroup cg, float start, float end, float lerpTime = 1) {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true) {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp (start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate ();
        }

        print ("done");

    }
}