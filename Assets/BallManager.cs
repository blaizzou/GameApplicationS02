using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject player_1;
    private GameObject player_2;
    void Start()
    {
        player_1 = GameObject.FindGameObjectsWithTag("Player")[0];
        player_2 = GameObject.FindGameObjectsWithTag("Player")[1];
    }

    void Update()
    {
        
    }



}
