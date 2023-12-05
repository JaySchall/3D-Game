using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool horizontallyMoving = false;
    private bool zero = true;
 //   public bool isJumping = false;
  //  public bool comingDown = false;
    public GameObject playerObject;
    public float startingSpeed = 20;
    private float speed;
    public float horizontalSpeed;
    private CharacterController controller;
    private Vector3 direction;
    public ScoreManager scoreManager;

    private int lane = 1;
    public float laneDistance = 4;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = startingSpeed;
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
        }
        else if (horizontalInput < 0 && zero)
        {
            zero = false;
            
            lane--;
            if (lane < 0)
            {
                lane = 0;
            }
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
        moveDirection.z = speed;

        // Use CharacterController.Move for movement
        controller.Move(moveDirection * Time.fixedDeltaTime);

        speed = Mathf.Floor(1.0f / 96.0f * currentPosition.z) + startingSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "rupee")
        {
            scoreManager.AddScore(100);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "obstacle")
        {
            Debug.Log("crash");
            SceneManager.LoadScene("Menu");
        }
    }
}
