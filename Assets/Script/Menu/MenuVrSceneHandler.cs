/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class MenuVrSceneHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

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