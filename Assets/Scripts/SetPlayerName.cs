using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlayerName : MonoBehaviour
{

    public Text playerNameDisplay;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Game Manager") != null) //if the game manager exists
        {
            playerNameDisplay.text = GameManager.playerName; //set the player name on the screen to the player's name they input in the main menu
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
