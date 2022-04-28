//////////////////////////////////////////////////////
// Assignment/Lab/Project: Project 3
//Name: Charles Wagner
//Section: 2020SP.SGD.212.4144
//Instructor: Aisha Eskandari
// Date: 4/22/2020
//////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{
    public float xScroll;
    public float yScroll;

    void Update()
    {
        float offsetX = Time.time * xScroll;
        float offsetY = Time.time * yScroll;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
