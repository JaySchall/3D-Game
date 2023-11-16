using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool zero = true;
    public float startingSpeed;
    private CharacterController controller;
    private Vector3 direction;

    private int lane = 1;
    public float laneDistance = 4;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = startingSpeed;
        float horizontalInput = Input.GetAxis("Horizontal");
        //Debug.Log(horizontalInput);
        if (horizontalInput > 0 && zero)
        {
            zero = false;
            lane++;
            if (lane > 2)
            {
                lane = 2;
            }
            Debug.Log(lane);
        }
        else if (horizontalInput < 0 && zero)
        {
            zero = false;
            
            lane--;
            if (lane < 0)
            {
                lane = 0;
            }
            Debug.Log(lane);
        }
        else if (horizontalInput == 0){
            zero = true;
        }
    }

    void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
}
