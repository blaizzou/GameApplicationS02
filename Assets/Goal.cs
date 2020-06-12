using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int score = 0;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("projectile"))
        {
            score++;
        }

    }
}
