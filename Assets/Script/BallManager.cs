using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallManager : MonoBehaviour, IPunObservable
{
    public GameObject[] players;
    public GameObject activePlayer;
    public ParticleSystem BallExplosion;
    public float maxVelo;
    private bool[] limited = { true, true };

    private float lapseVeloCap = 0.2f;
    private float timerVeloCap = 0;
    private float looseVelo = 0.1f;
    [SerializeField]
    private AudioSource ballBounce;
    [SerializeField]
    private AudioSource ballHit;

    private Rigidbody rb;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1)
            activePlayer = players[0];
        print(players.Length);
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        timerVeloCap -= Time.deltaTime;
        if (timerVeloCap < 0)
        {
            capVelocity();
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rb.position);
            stream.SendNext(rb.rotation);
            stream.SendNext(rb.velocity);
        }
        else
        {
            rb.position = (Vector3)stream.ReceiveNext();
            rb.rotation = (Quaternion)stream.ReceiveNext();
            rb.velocity = (Vector3)stream.ReceiveNext();

            float lag = Mathf.Abs((float)(PhotonNetwork.Time - info.timestamp));
            rb.position += rb.velocity * lag;
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

    bool IsVelocitySuperiorTo(float maxV)
    {
        if (rb.velocity.x > maxV)
            return true;
        else if (rb.velocity.x < -maxV)
            return true;

        if (rb.velocity.y > maxV)
            return true;
        else if (rb.velocity.y < -maxV)
            return true;

        if (rb.velocity.z > maxV)
            return true;
        else if (rb.velocity.z < -maxV)
            return true;

        return false;
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BatFollower"))
            ballHit.Play();
        else
            ballBounce.Play();

        if (!collision.collider.CompareTag("LeftHand") && IsVelocitySuperiorTo(5.0f))
        {
            BallExplosion.Stop();
            BallExplosion.Play();
        }

    }

}
