using System.Collections;
using Photon.Pun;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    public static GameSetupController GS;

    public Transform[] spawnPoints;
    private void OnEnable()
    {
        if (GameSetupController.GS == null)
        {
            GameSetupController.GS = this;
        }
    }

    void Start()
    {

        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("creating Player");
        int spawnPicker = Random.Range(0, GameSetupController.GS.spawnPoints.Length);
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("photonPrefabs", "Player"),
        GameSetupController.GS.spawnPoints[spawnPicker].position, Quaternion.identity);
    }
}
