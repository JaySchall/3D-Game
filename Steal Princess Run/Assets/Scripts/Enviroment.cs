using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    //controls player changing lanes WITHOUT model turning left or right.
    public static float leftSide = -1.0f;
    public static float rightSide = 1.0f;
    public float internalLeft;
    public float internalRight;

    // Update is called once per frame
    void Update()
    {
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
