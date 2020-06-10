using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    public enum PickUpType
    {
        Shield,
        Speed,
        Bigger
    }

    public PickUpType Type;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "projectile")
        {
            collider.GetComponent<BallManager>().player_1.GetComponent<PlayerState>().PickUp(Type);
            DestroyPickUp();
        }
    }

    public void DestroyPickUp()
    {
        Destroy(gameObject);
    }
}
