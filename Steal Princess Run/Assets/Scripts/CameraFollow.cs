using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f;
    public float offset = 10;

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;

            // Keep the same y and z values of the camera, only change the x value
            targetPosition = new Vector3(transform.position.x, transform.position.y, targetPosition.z - offset);

            // Use Vector3.Lerp to smoothly interpolate between the current position and the target position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}
