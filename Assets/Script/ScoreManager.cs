using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text score;
    public static int scoreValue = 0;
    void Start()
    {
        score = GetComponent<Text>();   
    }

    
    void Update()
    {
        score.text = "Point : " + scoreValue;
    }
}
