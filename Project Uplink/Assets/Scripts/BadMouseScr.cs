using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMouseScr : MonoBehaviour
{
    public float speed;
    public Transform tm;
    public Rigidbody2D rb;
    public Vector3 targetPosition;

    public void Update()
    {
        //To Do: we will move the evil mouse to the target position and either 
        //give control back to the player or create another target position
    }
}
