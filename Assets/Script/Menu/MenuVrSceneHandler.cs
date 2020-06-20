/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class MenuVrSceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    public GameObject mainMenu;
    public GameObject gameStart;
    public LobbyController lobbyController;

    public RoomController roomController;

    public RoomInfos roomInfos;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "training btn")
        {
            SceneManager.LoadScene ("TargetPractice");
        } else if (e.target.name == "multiplayer btn")
        {
            mainMenu.SetActive(false);
            gameStart.SetActive(true);
        }
        else if (e.target.name == "exit btn")
        {
            Application.Quit();
        }
        else if (e.target.name == "Enter")
        {
            lobbyController.JoinLobbyOnClick();
        }
        else if (e.target.name == "createBtn")
        {
            lobbyController.CreateRoom();
        }
        else if (e.target.name == "backBtn")
        {
            lobbyController.MatchMakingCancel();
        }
        else if (e.target.name == "startBtn")
        {
            roomController.startGame();
        }
        else if (e.target.name == "leaveBtn")
        {
            roomController.BackOnClick();
        }
        else if (e.target.name == "Ready btn")
        {
            roomInfos.readyOnClick();
        }
        else if (e.target.name == "not Ready btn")
        {
            roomInfos.cancelOnClick();
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
           if (e.target.name == "training btn")
        {
            Debug.Log("training btn was clicked");
        } else if (e.target.name == "multiplayer btn")
        {
            Debug.Log("multiplayer btn was clicked");
        }
        else if (e.target.name == "exit btn")
        {
            Debug.Log("exit btn was clicked");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was clicked");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
           if (e.target.name == "training btn")
        {
            Debug.Log("training btn was clicked");
        } else if (e.target.name == "multiplayer btn")
        {
            Debug.Log("multiplayer btn was clicked");
        }
        else if (e.target.name == "exit btn")
        {
            Debug.Log("exit btn was clicked");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was clicked");
        }
    }
}