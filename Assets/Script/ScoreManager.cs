using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text score;
    public float chrono;
    public static int scoreValue = 0;

    private float time;
    void Start()
    {
        time = chrono;
        score = GetComponent<Text>();   
    }

    
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            score.text = "Point : " + scoreValue + "\nRemaining Time : " + (int)time;

        }

    }
}
