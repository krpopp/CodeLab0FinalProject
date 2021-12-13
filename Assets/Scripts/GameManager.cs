using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //a static variable belongs only to the class
    //not the object
    //what that means is there will only be ONE playerName
    public static string playerName; 

    // Start is called before the first frame update
    void Start()
    {
        //this allows the game manager to not get destroyed when we load the next scene
        //so we can keep our player name
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("player name is " + playerName);
    }
}
