using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;

    public Slider healthSlider; //the slider is a UI element that will display our health

    public float health = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {

        //movement code
        Vector3 newPos = transform.position;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos.x += speed * Time.deltaTime;
        }
        transform.position = newPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy") //when we hit an enemy
        {
            health -= 0.1f; //decrease our health
            healthSlider.value = health; //set the slider to be our health value
        }
    }


}
