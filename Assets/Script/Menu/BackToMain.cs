/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    private Vector3 scaleChange = new Vector3(0.1f, 0.1f, 0f);

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "backToMainBtn")
        {
            SceneManager.LoadScene ("MenuVr");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
       if (e.target.name == "backToMainBtn")
        {
            e.target.localScale += scaleChange;
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "backToMainBtn")
        {
            e.target.localScale -= scaleChange;
        }
    }
}