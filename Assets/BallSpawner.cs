using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;
    private float timer;

    void Start() {
        // Instantiate(ball, transform.position, transform.rotation);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Instantiate(ball, transform.position, transform.rotation);
            timer = 2f;
        }
    }
}
