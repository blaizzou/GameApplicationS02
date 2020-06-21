using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text text1;
    public Text text2;
    
    public GameObject endgame;

    private bool locked;
    public int score = 0;

    private UIFader UI;
    private void Start() {
        UI = GetComponent<UIFader>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("projectile") && locked == false)
        {
            UI.FadeIn();
            score++;
            StartCoroutine(waitForSec(1));
            locked = false;
            StartCoroutine(waitForSec(4));
            text1.text = score+"";
            text2.text = score+"";
            locked = true;
            if (score >= 5)
                endgame.SetActive(true);
        }

    }

    IEnumerator waitForSec(int sec) {
        yield return new WaitForSeconds(sec);
        UI.FadeOut();
    }
}
