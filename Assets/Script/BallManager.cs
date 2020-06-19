using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject activePlayer;
    public float maxVelo;
    private bool[] limited = { true, true };

    private float lapseVeloCap = 0.2f;
    private float timerVeloCap = 0;
    private float looseVelo = 0.1f;

    private Rigidbody rb;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1)
            activePlayer = players[0];
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        print(rb.velocity);
        timerVeloCap -= Time.deltaTime;
        if (timerVeloCap < 0)
        {
            capVelocity();
        }

    }

    void capVelocity()
    {
        Vector3 newVelo = rb.velocity;
        if (rb.velocity.x > maxVelo)
            newVelo.x -= looseVelo;
        else if (rb.velocity.x < -maxVelo)
            newVelo.x += looseVelo;

        if (rb.velocity.y > maxVelo)
            newVelo.y -= looseVelo;
        else if (rb.velocity.y < -maxVelo)
            newVelo.y += looseVelo;

        if (rb.velocity.z > maxVelo)
            newVelo.z -= looseVelo;
        else if (rb.velocity.z < -maxVelo)
            newVelo.z += looseVelo;

        rb.velocity = newVelo;
    }

    public void changeActivePlayer(Transform newPlayer)
    {
        timerVeloCap = lapseVeloCap;
        if (players.Length > 1)
        {
            if (newPlayer.position == players[0].transform.position)
                activePlayer = players[0];
            else
                activePlayer = players[1];

        }
    }

}
