using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR.Extras;

public class ScoreManager : MonoBehaviour
{
    private Text score;
    public float chrono;
    public static int scoreValue = 0;
    public GameObject GameOver;
    public GameObject LeftHand;

    private float time;
    void Start()
    {
        time = chrono;
        score = GetComponent<Text>();
        LeftHand = GameObject.FindGameObjectWithTag("LeftHand");

    }

    
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            score.text = "Point : " + scoreValue + "\nRemaining Time : " + (int)time;
        }
        else
        {
            GameOver.SetActive(true);
            LeftHand.GetComponent<SteamVR_LaserPointer>().enabled = true;
        }
    }
}
