using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float leftCamBoundary = 0;
    [SerializeField] float rightCamBoundary = 11;
    [SerializeField] float camSlowingAccel = -0.1f;

    Vector3 cameraVel;

    // Update is called once per frame
    void Update()
    {
        //Move Position
        transform.position += cameraVel * Time.deltaTime;

        //Update Velocity
        if (cameraVel.x < 0)
        {
            cameraVel = cameraVel - (Vector3.right * camSlowingAccel * Time.deltaTime);
        }
        if (cameraVel.x > 0)
        {
            cameraVel = cameraVel - (Vector3.left * camSlowingAccel * Time.deltaTime);
        }

        if (transform.position.x < leftCamBoundary)
        {
            transform.position = new Vector3(leftCamBoundary, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightCamBoundary)
        {
            transform.position = new Vector3(rightCamBoundary, transform.position.y, transform.position.z);
        }
    }

    public void SetVelocity(float vel, int xDir /*0 = left | 1 = right*/)
    {
        if (xDir == 0)
        {
            cameraVel = new Vector3(-vel, 0, 0);
        }
        else if (xDir == 1)
        {
            cameraVel = new Vector3(vel, 0, 0);
        }
    }
}
