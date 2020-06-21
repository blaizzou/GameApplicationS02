using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text text1;
    public Text text2;

    public int score = 0;

    private UIFader UI;
    private void Start() {
        UI = GetComponent<UIFader>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("projectile"))
        {
            UI.FadeIn();
            score++;
            StartCoroutine(waitForSec(5));
            text1.text = score+"";
            text2.text = score+"";
        }

    }

    IEnumerator waitForSec(int sec) {
        yield return new WaitForSeconds(sec);
        UI.FadeOut();
    }
}
