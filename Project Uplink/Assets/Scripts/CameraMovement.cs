using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera camera1;

    public int speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float step = 1; //2 is hard mode

        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x -= -step / speed; //50
        Camera.main.gameObject.transform.position = cameraPosition;
    }
    

}
