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

    private Transform shieldPos;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        print("ball collide");
        if (collider.tag == "projectile")
        {
            collider.GetComponent<BallManager>().activePlayer.GetComponent<PlayerState>().PickUp(Type);
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
        shieldPos = GameObject.FindGameObjectWithTag("ShieldSpawn").transform;

        Shield.SetActive(true);
        Shield.transform.position = shieldPos.position;
        gameObject.SetActive(false);
    }

    public void DestroyPickUp()
    {
        Destroy(gameObject);
    }
}
