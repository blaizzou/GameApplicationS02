using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    [SerializeField]
    private Goal first;
    [SerializeField]
    private Goal second;
    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = "" + first.score + " : "  + second.score;
    }
}
