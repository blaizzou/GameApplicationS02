using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
    public float lifetime;
    public float hitResistance;

    private float life = 0;
    private GameObject parent;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        print("shield alive");
        life += Time.deltaTime;
        if (life > lifetime)
            destroyShield();
    }

    void destroyShield()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            life -= 4;
        }
    }
}
