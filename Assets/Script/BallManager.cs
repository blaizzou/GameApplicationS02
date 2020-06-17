using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject activePlayer;
    public float maxVelo;
    private float[] limited = { 0, 0 };

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
        print(limited[0]);
        UnlimitedTimer();
        timerVeloCap -= Time.deltaTime;
        if (timerVeloCap < 0)
        {
            print(IsActive(players[0].transform) && limited[0] <= 0 );
            //|| (players.Length == 2 && (IsActive(players[1].transform) && limited[1] <= 0))
            if ((IsActive(players[0].transform) && limited[0] <= 0) )
                capVelocity();
        }
    }

    void capVelocity()
    {
        //print(rb.velocity);
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

    public void setUnlimitedVelo(float time)
    {
        if (IsActive(players[0].transform))
        {
            print("set timer");

            limited[0] = time;
        } else if (IsActive(players[1].transform))
        {
            limited[1] = time;
        }
    }

    bool IsActive(Transform check)
    {
        if (check == activePlayer.transform)
            return true;
        return false;
    }

    void UnlimitedTimer()
    {
        
        for (int i = 0; i < players.Length; i++)
        {
            if ((IsActive(players[i].transform) && limited[i] > 0))
            {
                print("oui");
                print(limited[i]);
                limited[i] -= Time.deltaTime;
            }
        }
    }
}
