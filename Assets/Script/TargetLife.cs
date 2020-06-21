using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLife : MonoBehaviour
{
    private Vector3 dir = new Vector3(1, 0, 0);

    public ParticleSystem bluePortal;
    public ParticleSystem greenPortal;
    public ParticleSystem yellowPortal;
    public ParticleSystem orangePortal;
    public ParticleSystem redPortal;
    private int lifeTarget = 5;
    private GameObject scoreMaster;
    private int score = 0;
    void Start()
    {
        greenPortal.Stop();
        yellowPortal.Stop();
        orangePortal.Stop();
        redPortal.Stop();
        scoreMaster = GameObject.FindGameObjectWithTag("Score");

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("projectile") && collision.gameObject.GetComponent<BallManager>().isActive())
        {
            ScoreManager.scoreValue += 1 + collision.gameObject.GetComponent<BallManager>().getCombo();
            collision.gameObject.GetComponent<BallManager>().increaseCombo();
            score++;
            if (score == 1)
            {
                bluePortal.Stop();
                greenPortal.Play();
            }
            if (score == 2)
            {
                greenPortal.Stop();
                yellowPortal.Play();
            }
            else if (score == 3)
            {
                yellowPortal.Stop();
                orangePortal.Play();
            }
            else if (score == 4)
            {
                orangePortal.Stop();
                redPortal.Play();
            }
            else if (score == 5)
            {
                redPortal.Stop();
                bluePortal.Play();
                scoreMaster.GetComponent<TargetBehavior>().ReCreateTarget();
            }
        }

    }

/*    private void targetMovement()
    {
        if (transform.position.x <= -1.5 || transform.position.x >= 1.5)
            dir = -dir;

        transform.position = transform.position + (dir * Time.deltaTime);
    }*/
}
