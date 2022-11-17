using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrappingScr : MonoBehaviour
{
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float upperConstraint = Screen.height;
    float lowerConstraint = Screen.height;
    float buffer = 1.0f;
    Camera camera;
    float distanceZ;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        distanceZ = Mathf.Abs(camera.transform.position.z + transform.position.z);
        leftConstraint = camera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        lowerConstraint = camera.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        upperConstraint = camera.ScreenToWorldPoint(new Vector3( 0.0f, Screen.height, distanceZ)).y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector3(rightConstraint - 0.10f, transform.position.y, transform.position.z);
        }

        if(transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector3(leftConstraint, transform.position.y, transform.position.z);
        }

        if(transform.position.y < lowerConstraint - buffer)
        {
            transform.position = new Vector3(transform.position.x, upperConstraint + buffer , transform.position.z);
        }
        if(transform.position.y > upperConstraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, lowerConstraint - buffer , transform.position.z);
        }
    }
}
