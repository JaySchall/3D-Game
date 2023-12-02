using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool horizontallyMoving = false;
    private bool zero = true;
 //   public bool isJumping = false;
  //  public bool comingDown = false;
    public GameObject playerObject;
    public float startingSpeed;
    public float horizontalSpeed;
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
            horizontallyMoving = true;
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
            horizontallyMoving = true;
        }
        else if (horizontalInput == 0){
            zero = true;
        }
    }

    void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 moveDirection = Vector3.zero;

        if (horizontallyMoving)
        {
            Vector3 targetPosition = new Vector3(laneDistance * (lane - 1), currentPosition.y, currentPosition.z);
            moveDirection = (targetPosition - currentPosition).normalized;
            moveDirection.x = moveDirection.x * horizontalSpeed;

            if ((targetPosition - currentPosition).sqrMagnitude < 0.01f)
            {
                horizontallyMoving = false;
                
            }
        }
      

        // Apply constant movement along the z-axis
        moveDirection.z = startingSpeed;

        // Use CharacterController.Move for movement
        controller.Move(moveDirection * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "rupee")
        {
            Destroy(other.gameObject);
        }
        
    }
}
