using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{

    public Text selectedText;

    public void start() {
            selectedText.text = "You have selected : char 1"; 
    }

    public void OnClickCharacterPick(int character) {
        if (PlayerInfo.PI != null) {
            selectedText.text = "You have selected : char " + (character + 1); 
            PlayerInfo.PI.mySelectedCharacter = character;
            PlayerPrefs.SetInt("MyCharacter", character);
        }
    }
}
