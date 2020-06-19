using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLife : MonoBehaviour
{
    private int score = 0;
    private Vector3 dir = new Vector3(1, 0, 0);

    public ParticleSystem bluePortal;
    public ParticleSystem yellowPortal;
    public ParticleSystem orangePortal;
    public ParticleSystem redPortal;
    private int lifeTarget = 4;
    private GameObject scoreMaster;
    void Start()
    {
        yellowPortal.Stop();
        orangePortal.Stop();
        redPortal.Stop();
        scoreMaster = GameObject.FindGameObjectWithTag("Score");

    }

    void Update()
    {
        if (score >= (lifeTarget * 2))
            targetMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("projectile"))
        {
            ScoreManager.scoreValue += 1;
            score++;
            if (ScoreManager.scoreValue % lifeTarget == 1)
            {
                bluePortal.Stop();
                yellowPortal.Play();
            }
            else if (ScoreManager.scoreValue % lifeTarget == 2)
            {
                yellowPortal.Stop();
                orangePortal.Play();
            }
            else if (ScoreManager.scoreValue % lifeTarget == 3)
            {
                orangePortal.Stop();
                redPortal.Play();
            }
            else if (ScoreManager.scoreValue % lifeTarget == 0)
            {
                redPortal.Stop();
                bluePortal.Play();
                scoreMaster.GetComponent<TargetBehavior>().ReCreateTarget();
            }
        }

    }

    private void targetMovement()
    {
        if (transform.position.x <= -1.5 || transform.position.x >= 1.5)
            dir = -dir;

        transform.position = transform.position + (dir * Time.deltaTime);
    }
}
