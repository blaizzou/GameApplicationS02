using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    private int score = 0;
    private Vector3 dir = new Vector3(1, 0, 0);
    void Start()
    {
        
    }

    void Update()
    {
        if (score >= 3)
            targetMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("projectile"))
        {
            ScoreManager.scoreValue += 1;
            score++;
        }

    }

    private void targetMovement()
    {
        if (transform.position.x <= -1.5 || transform.position.x >= 1.5)
            dir = -dir;

        transform.position = transform.position + (dir * Time.deltaTime);
    }
}
