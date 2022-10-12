using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MouseScr : MonoBehaviour
{
    public bool playerControl = true;
    public Vector3 myMousePosition;
    public Texture2D myMouse;
    public GameObject badMouse;
    public bool badMouseExists = false;

    public void Update()
    {

        if (playerControl)
        {
            //player is in control
            Cursor.SetCursor(myMouse, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            //infosqueak is in control

            if (!badMouseExists)
            {
                //makes the cursor invisible and stuck at the middle of the screen
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                //finds the current position of the mouse
                myMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                //makes sure that the mouse is visible
                myMousePosition.z = 0f;

                //creates the bad mouse where the mouse was
                Instantiate(badMouse, myMousePosition, Quaternion.identity);

                //stops running the if block once the bad mouse is created
                badMouseExists = true;
            }
            
        }
    }
}
