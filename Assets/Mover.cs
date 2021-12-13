using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public float percent; //how far along we are on our lerp
    float mod = 1; //which direction we should go (towards the start or the end)

    public Vector3 startPosition; //where we are beginning
    public Vector3 endPosition; //where we are ending

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        percent += Time.deltaTime * mod; //increase the percentage a bit, in the direction we want to go

        if(percent < 0 || percent > 1) //if we reach the end of the percentage (either 0% or 100%)
        { 
            mod *= -1; //reverse direction
            percent += Time.deltaTime * mod; //reverse the percentage
        }

        //LERP = linear interpolation; this allows us to smoothly move between 2 points
        //SLERP = spherical interpolation

        //transform.position = Vector3.Lerp(startPosition, endPosition, percent);
        transform.position = Vector3.Slerp(startPosition, endPosition, percent);
    }
}
