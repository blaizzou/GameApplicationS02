using System.Collections;
using Photon.Pun;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupController : MonoBehaviour
{
    public static GameSetupController GS;

    public Transform[] spawnPoints;
    private GameObject newPlayer;
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
        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;
        int i = 0;
        int currentPlayerNb = 0;

        foreach (Photon.Realtime.Player player in players)
        {
            if (player.UserId != null)
                currentPlayerNb = i;
            i++;
        }
        if (PhotonNetwork.CountOfPlayers <= 1)
            PhotonNetwork.OfflineMode = true;
        newPlayer = PhotonNetwork.Instantiate(Path.Combine("photonPrefabs", "Player"),
        GameSetupController.GS.spawnPoints[currentPlayerNb].position, GameSetupController.GS.spawnPoints[currentPlayerNb].rotation);
    }
}
