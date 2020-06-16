using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnline : MonoBehaviour
{

    [SerializeField]
    private GameObject playerVR;
    void Start()
    {
        playerVR.SetActive(true);
    }
}
