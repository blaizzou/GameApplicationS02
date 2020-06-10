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
    public GameObject Shield;

    private Transform shielPos;

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
            if (Type == PickUpType.Shield)
                CreateShield();
            else
                DestroyPickUp();
        }
    }

    private void CreateShield()
    {

        /*        shielPos.position = transform.position;
                shielPos.position = new Vector3(shielPos.position.x, 2, shielPos.position.y);
                Instantiate(Shield, shielPos);*/

        Shield.SetActive(true);
        gameObject.SetActive(false);
    }

    public void DestroyPickUp()
    {
        Destroy(gameObject);
    }
}
