using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public ParticleSystem BoostGreen;
    public ParticleSystem BoostYellow;
    public ParticleSystem BoostBlue;

    public GameObject Bat;

    private GameObject Ball;
    private float time = 0;
    private bool stateGreenPU;

    public float powerUpTimeLapse;
    void Start()
    {
        BoostYellow.Stop();
        BoostGreen.Stop();
        BoostBlue.Stop();
        Ball = GameObject.FindGameObjectWithTag("projectile");
    }

    void Update()
    {
        checkPowerUpState();
    }

    private void checkPowerUpState()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (stateGreenPU && time <= 0)
            {
                Bat.transform.localScale /= 1.5f;
            }
        }
    }

    private void IncreaseSize()
    {
        Bat.transform.localScale *= 1.5f;
        time = powerUpTimeLapse;
        stateGreenPU = true;
    }

    public void PickUp(PickUpManager.PickUpType type)
    {
        if (type == PickUpManager.PickUpType.Bigger)
        {
            IncreaseSize();
            BoostGreen.Play();
        }
        if (type == PickUpManager.PickUpType.Shield)
        {
            BoostBlue.Play();
        }
        if (type == PickUpManager.PickUpType.Speed)
        {
            BoostYellow.Play();
            Ball.GetComponent<BallManager>().setUnlimitedVelo(time);
        }
    }
}
