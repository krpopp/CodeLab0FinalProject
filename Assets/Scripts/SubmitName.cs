using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SubmitName : MonoBehaviour
{

    public Text inputField; //where the player puts there anme

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitButton(string nextScene)
    {
        GameManager.playerName = inputField.text; //set the playerName value to whatever the player entered
        SceneManager.LoadScene(nextScene); //load the new scene
    }
}
