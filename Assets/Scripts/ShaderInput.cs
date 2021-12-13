using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderInput : MonoBehaviour
{
    public Material mat; //reference to the material
    float f; //base for our random number

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        f += Time.deltaTime; //increase our base number by a bit
        mat.SetFloat("_Rand", Mathf.PerlinNoise(f, 1)); //set the random float we're using in our shader
    }
}
